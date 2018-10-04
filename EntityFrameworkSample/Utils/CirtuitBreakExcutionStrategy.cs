using Polly;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Utils
{
    //利用 Polly自定义实现执行策略
    public class CirtuitBreakExcutionStrategy : IDbExecutionStrategy
    {
        private Policy _policy;
        public CirtuitBreakExcutionStrategy(Policy policy)
        {
            _policy = policy;
        }
        public bool RetriesOnFailure { get { return true; }}

        public void Execute(Action operation)
        {
            _policy.Execute(() =>
            {
                operation.Invoke();
            });
        }

        public TResult Execute<TResult>(Func<TResult> operation)
        {
            return _policy.Execute(() =>
                {
                    return operation.Invoke();
                });
        }

        public async Task ExecuteAsync(Func<Task> operation, CancellationToken cancellationToken)
        {
            await _policy.ExecuteAsync(() =>
                    {
                        return operation.Invoke();
                    });
        }

        public async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> operation, CancellationToken cancellationToken)
        {
            return await _policy.ExecuteAsync(() =>
                    {
                        return operation.Invoke();
                    });
        }
    }
    //简单实现执行策略
    public class SqlServerExecutionStrategy:DbExecutionStrategy
    {
        public SqlServerExecutionStrategy()
        {

        }

        public SqlServerExecutionStrategy(int maxRetryCount, TimeSpan maxDelay):base(maxRetryCount,maxDelay)
        {

        }


        protected override bool ShouldRetryOn(Exception ex)
        {
            bool bRetry = false;
            if(ex is SqlException objSqlExcetion)
            {
                var lstErrorNumbersToRetry = new List<int>() { 5 };
                if(objSqlExcetion.Errors.Cast<SqlError>().Any(A=>lstErrorNumbersToRetry.Contains(A.Number)))
                {
                    bRetry = true;

                }

            }
            return bRetry;
        }
    }


}
