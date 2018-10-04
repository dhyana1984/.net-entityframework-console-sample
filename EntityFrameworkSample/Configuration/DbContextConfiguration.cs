using EntityFrameworkSample.EFLog;
using EntityFrameworkSample.Model;
using EntityFrameworkSample.Utils;
using Polly;
using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Configuration
{
  public  class DbContextConfiguration:DbConfiguration
    {
      
        public Policy _policy;
        public DbContextConfiguration()
        {
            //添加Sql格式化器
            // SetDatabaseLogFormatter((context, action) => new SingleLineFormmatter(context, action)); 

            //添加Nlog拦截器
            //DbInterception.Add(new NLogCommandInterceptor());

            //添加Sql执行时间Log拦截器,基于IDbCommandInterceptor接口 
            //DbInterception.Add(new DatabaseInterceptorLogger());

            //添加自定义SqlProfiler,基于 DbCommandInterceptor类
            //DbInterception.Add(new SQLProfiler(@"F:\log.txt", 1));

            //添加sql命令去空格拦截器
            //AddInterceptor(new StringTrimmerInterceptor());

            //添加基于Polly的弹性连接策略     
            SetDatabaseInitializer(new DropCreateDatabaseIfModelChanges<EfDbContext>());
            _policy = Policy.Handle<Exception>().CircuitBreaker(3, TimeSpan.FromSeconds(60));
            SetExecutionStrategy(SqlProviderServices.ProviderInvariantName, () => new CirtuitBreakExcutionStrategy(_policy));


        }
    }
}
