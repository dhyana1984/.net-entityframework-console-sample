using EntityFrameworkSample.Entity;
using EntityFrameworkSample.Model;
using EntityFrameworkSample.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Client
{
    class PollyConcurrency
    {
        public PollyConcurrency()
        {
            using (var db = new EfDbContext())
            using (var db1 = new EfDbContext())
            {
                var student = db.Students.FirstOrDefault(t => t.Id == 2);
                var student1 = db1.Students.FirstOrDefault(t => t.Id == 2);

                student.Name = "Chris1";
                student.Age = 25;
                db.SaveChanges();

                student1.Name = "Chris2";
                student1.Age = 26;
                //封装并发异常并利用Polly自定义重试策略
                db1.SaveChanges(RefreshConflict.ClientWins);

             

            }
        }
       
    }
}
