using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.EFLog
{
  public class SQLProfiler :DbCommandInterceptor
    {
        private readonly string _logFile;
        private readonly int _executionTime;
        public SQLProfiler(string logFile, int executionTime)
        {
            _logFile = logFile;
            _executionTime = executionTime;
        }
        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Execiting(interceptionContext);
            base.ReaderExecuting(command, interceptionContext);
        }

        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Executed(command, interceptionContext);
            base.ReaderExecuted(command, interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Execiting(interceptionContext);
            base.ScalarExecuting(command, interceptionContext);
        }

        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Executed(command, interceptionContext);
            base.ScalarExecuted(command, interceptionContext);
        }

        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Executed(command, interceptionContext);
            base.NonQueryExecuted(command, interceptionContext);
        }

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Execiting(interceptionContext);
            base.NonQueryExecuting(command, interceptionContext);
        }

    

        private void Execiting<T>(DbCommandInterceptionContext<T> interceptionContext)
        {
            var timer = new Stopwatch();
            interceptionContext.SetUserState("timer",timer);
            timer.Start();
        }

        private void Executed<T>(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            var timer = (Stopwatch)interceptionContext.FindUserState("timer");
            timer.Stop();

            if(interceptionContext.Exception != null)
            {
                File.AppendAllLines(_logFile, new string[]
                {
                    "错误SQL语句",
                    interceptionContext.Exception.Message,
                    command.CommandText,
                    Environment.StackTrace,
                    string.Empty,
                    string.Empty
                });
            }
            else if(timer.ElapsedMilliseconds >= _executionTime)
            {
                File.AppendAllLines(_logFile, new string[]
                {
                    string.Format("耗时SQL语句({0}ms)",timer.ElapsedMilliseconds),
                    command.CommandText,
                    Environment.StackTrace,
                    string.Empty,
                    string.Empty
                });
            }
        }
    }
}
