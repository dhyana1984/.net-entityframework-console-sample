using Polly;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Utils
{
    //利用Polly实现自定义重试解决冲突
    public static partial class DbContextExtentions
    {
        public static int SaveChanges(this DbContext context, Action<IEnumerable<DbEntityEntry>> resolveConflicts, int retryCount = 3)
        {
            var retryPolicy = Policy
                                .Handle<DbUpdateConcurrencyException>()
                                .Retry(retryCount, (ex, count) =>
                                 {
                                     resolveConflicts(((DbUpdateConcurrencyException)ex).Entries);
                                 });
            return retryPolicy.Execute(context.SaveChanges);
        }
    }

    public enum RefreshConflict
    {
        StoreWins,
        ClientWins,
        MergeClientAndStore
    }

    //为解决并发冲突，实体及其跟踪信息都需要刷新，为每个冲突应用其刷新来实现更具体的SaveChanges
    public static partial class DbContextExtentions
    {
        public static int SaveChanges(this DbContext context, RefreshConflict refreshMode, int retryCount = 3)
        {
            if (retryCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(retryCount), $"{retryCount}必须大于0");
            }

            return context.SaveChanges(conflicts => conflicts.ToList().ForEach(tracking => tracking.Refresh(refreshMode)), retryCount);
        }

        public static int SaveChanges(this DbContext context, RefreshConflict refreshMode) =>
            context.SaveChanges(conflicts => conflicts.ToList().ForEach(tracking => tracking.Refresh(refreshMode)));
    }

    public static class RefreshEFStateExtentions
    {
        public static DbEntityEntry Refresh(this DbEntityEntry tracking, RefreshConflict refreshMoode)
        {
            switch (refreshMoode)
            {
                case RefreshConflict.StoreWins:
                    {
                        //当实体被删除时，重新加载，设置追踪状态为Detached
                        //当实体被更新时，重新加载，设置追踪状态为Unchanged
                        tracking.Reload();
                        break;
                    }
                case RefreshConflict.ClientWins:
                    {
                        DbPropertyValues databaseValues = tracking.GetDatabaseValues();
                        if (databaseValues == null)
                        {
                            //当实体被删除时，设置追踪状态为Detached, 此时客户端无所谓获胜
                            tracking.State = EntityState.Detached;
                        }
                        else
                        {
                            //当实体被更新时，刷新数据库原始值
                            tracking.OriginalValues.SetValues(databaseValues);
                        }
                        break;
                    }
                case RefreshConflict.MergeClientAndStore:
                    {
                        DbPropertyValues databaseValues = tracking.GetDatabaseValues();
                        if (databaseValues == null)
                        {
                            //当实体被删除时，设置追踪状态为Detached, 当然此时客户端没有合并的数据，并设置追踪状态为Detached
                            tracking.State = EntityState.Detached;
                        }
                        else
                        {
                            //当实体被更新时
                            DbPropertyValues originValues = tracking.OriginalValues.Clone();
                            tracking.OriginalValues.SetValues(databaseValues);

                            //如果数据库中对于属性有不同值，保留数据库中的值
                            databaseValues.PropertyNames.Where(property => !object.Equals(originValues[property], databaseValues[property]))
                                                        .ToList()
                                                        .ForEach(property => tracking.Property(property).IsModified = false);
                        }
                        break;
                    }
            

              
            }
            return tracking;
        }
    }
}
