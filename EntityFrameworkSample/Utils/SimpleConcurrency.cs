using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EntityFrameworkSample.Utils
{
    //利用循环实现最简单的重试机制
    public static partial class DbContextExtentions
    {

        //public static int SaveChanges(this DbContext context, Action<IEnumerable<DbEntityEntry>> resolveConflicts, int retryCount = 3)
        //{
        //    if(retryCount <= 0)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(retryCount), $"{retryCount}必须大于0");
        //    }

        //    for (int retry = 0; retry < retryCount; retry++)
        //    {
        //        try
        //        {
        //            return context.SaveChanges();
        //        }
        //        catch(DbUpdateConcurrencyException exception) when (retry < retryCount)
        //        {
        //            resolveConflicts(exception.Entries);
        //        }
        //    }

        //    return context.SaveChanges();
        //}


    }
}
