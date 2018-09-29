using EntityFrameworkSample.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.EFLog
{
    /// <summary>
    /// 如果查询和插入时间超过一秒或者包含异常信息就将其持久化到数据库中,基于IDbCommandInterceptor
    /// </summary>
    public class DatabaseInterceptorLogger : IDbCommandInterceptor
    {
        static readonly ConcurrentDictionary<DbCommand, DateTime> MStartTime = new ConcurrentDictionary<DbCommand, DateTime>();
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Log(command, interceptionContext);
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            OnStart(command);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Log(command, interceptionContext);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            OnStart(command);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Log(command, interceptionContext);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            OnStart(command);
        }

        private static void Log<T>(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            DateTime startTime;
            TimeSpan duration;

            //从字典中移除计算时间，若开始时间和当前时间不相等，则计算耗时 
            MStartTime.TryRemove(command, out startTime);
            if(startTime != default(DateTime))
            {
                duration = DateTime.Now - startTime;
            }
            else
            {
                duration = TimeSpan.Zero;
            }
            const int requestId = -1;

            var parameters = new StringBuilder();
            foreach (DbParameter param in command.Parameters)
            {
                parameters.AppendLine(param.ParameterName + " " + param.DbType + " = " + param.Value);
            }

            var message = interceptionContext.Exception == null ? $"Database call took {duration.TotalSeconds.ToString("N3")} sec. RequestId {requestId} \r\nCommand:\r\n{parameters + command.CommandText}" : $"EF Database call failed after {duration.TotalSeconds.ToString("N3")} sec. RequestId {requestId} \r\nCommand:\r\n{parameters.ToString() + command.CommandText}\r\nError:{interceptionContext.Exception} ";

            if(duration.TotalSeconds>1 || message.Contains("EF Database call failed after "))
            {
                using (var db = new EfDbContext())
                {
                    var error = new Error
                    {
                        TotalSeconds = (decimal)duration.TotalSeconds,
                        Active = true,
                        CommandType = Convert.ToString(command.CommandType),
                        CreateDate = DateTime.Now,
                        Exception = Convert.ToString(interceptionContext.Exception),
                        FileName = "",
                        InnerException = interceptionContext.Exception == null ? "" : Convert.ToString(interceptionContext.Exception.InnerException),
                        Parameters = parameters.ToString(),
                        Query = command.CommandText,
                        RequireId = 0
                    };

                    if(db.Errors.Any(t=>t.Parameters == error.Parameters && t.Query == error.Query))
                    {
                        return;
                    }
                    db.Errors.Add(error);
                    db.SaveChanges();


                }
            }
        }

        private static void OnStart (DbCommand command)
        {
            MStartTime.TryAdd(command, DateTime.Now);
        }

    }
}
