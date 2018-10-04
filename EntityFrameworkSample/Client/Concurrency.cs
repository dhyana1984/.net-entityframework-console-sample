using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Client
{
    class Concurrency
    {
            //  using(var db = new EfDbContext())
            //using (var db1 = new EfDbContext())
            //{
            //    var student = db.Students.FirstOrDefault(t=>t.Id==2);
            //    var student1 = db1.Students.FirstOrDefault(t => t.Id == 2);

            //    student.Name = "Chris1";
            //    db.SaveChanges();

            //    student1.Name = "Chris2";

            // 简单冲突解决 
            //    try
            //    {
            //        db1.SaveChanges();
            //    }
            //    catch(DbUpdateConcurrencyException ex)
            //    {
            //        //获取并发异常被追踪的实体
            //        var tracking = ex.Entries.Single();

            //        //获取数据库原始值对象
            //        var original = (Student)tracking.OriginalValues.ToObject();

            //        //获取更新后数据库最新的值对象
            //        var database = (Student)tracking.GetDatabaseValues().ToObject();

            //        //获取当前内存中的值对象
            //        var current = (Student)tracking.CurrentValues.ToObject();

            //        var origin = $"原始值：{original.Name}";
            //        Console.WriteLine(origin);

            //        var databaseBalue = $"数据库中值：{database.Name}";
            //        Console.WriteLine(databaseBalue);

            //        var update = $"更新的值：{current.Name}";
            //        Console.WriteLine(update);

            //        ex.Entries.Single().Reload();
            //        tracking.OriginalValues.SetValues(tracking.GetDatabaseValues());
            //        db1.SaveChanges();
              
            //    }
              
                    
           
            //}
    }
}
