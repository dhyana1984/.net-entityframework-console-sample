using EntityFrameworkSample.EFLog;
using EntityFrameworkSample.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Configuration
{
  public  class DbContextConfiguration:DbConfiguration
    {
        public DbContextConfiguration()
        {
            // SetDatabaseLogFormatter((context, action) => new SingleLineFormmatter(context, action));
            //DbInterception.Add(new NLogCommandInterceptor());
            //DbInterception.Add(new DatabaseInterceptorLogger());
            DbInterception.Add(new SQLProfiler(@"F:\log.txt", 1));
            AddInterceptor(new StringTrimmerInterceptor());

            
        }
    }
}
