using NLog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.EFLog
{
    public class NLogCommandInterceptor : IDbCommandInterceptor
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfNoAsync(command, interceptionContext);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfNoAsync(command, interceptionContext);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfNoAsync(command, interceptionContext);
        }

        private void LogIfNoAsync<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if(!interceptionContext.IsAsync)
            {
                Logger.Warn("Non-async command used:{0}", command.CommandText);
            }
        }

        private void LogIfError<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
           // DbInterception.Add(new NLogCommandInterceptor());
           if(interceptionContext.Exception!=null)
            {
                Logger.Error("Command {0} failed with exception {1}", command.CommandText, interceptionContext.Exception);
            }
        }
      
        

    }
}
