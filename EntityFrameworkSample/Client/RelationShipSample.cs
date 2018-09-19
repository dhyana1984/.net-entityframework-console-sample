using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Client
{
    class RelationShipSample
    {
         //using(var efDbContext = new EfDbContext())
         //   {
         //       //efDbContext.Blogs.Add(new Blog()
         //       //{
         //       //    Name = "Jeffky",
         //       //    Url = "http://www.163.com"

         //       //});
         //       //var user = efDbContext.Users.Find(1);

         //       //var originalValues = efDbContext.Entry(user).ComplexProperty(t => t.Address).OriginalValue;
         //       //var currentValues = efDbContext.Entry(user).ComplexProperty(t => t.Address).CurrentValue;

         //       //新增by隐式多对多
         //       //var customer = new Customer()
         //       //{
         //       //    Name = "Chris",
         //       //    Email = "aaa@aa.com",
         //       //    CreateTime = DateTime.Now,
         //       //    ModifiedTime = DateTime.Now,
         //       //    Orders = new List<Order>
         //       //   {
         //       //       new Order
         //       //       {
         //       //            Quanatity=12,
         //       //            Price=1500,
         //       //            CreateTime=DateTime.Now,
         //       //            ModifiedTime=DateTime.Now
         //       //       },
         //       //       new Order
         //       //       {
         //       //            Quanatity=10,
         //       //            Price=2500,
         //       //            CreateTime=DateTime.Now,
         //       //            ModifiedTime=DateTime.Now
         //       //       }
         //       //   }
         //       //};


         //       //新增by显式多对多
         //       var student = new Student
         //       {
         //           Name = "Chris",
         //           Age = 26,
         //           CreateTime = DateTime.Now,
         //           ModifiedTime = DateTime.Now,
         //           StudentCourses= new List<StudentCourse>
         //           {
         //               new StudentCourse
         //               {
         //                    Course= new Course
         //                    {
         //                       Name = "Web API",
         //                       MaxmumStrength = 12,
         //                       CreateTime = DateTime.Now,
         //                       ModifiedTime = DateTime.Now,

         //                    },
         //                        CreateTime = DateTime.Now,
         //                       ModifiedTime = DateTime.Now,

         //               },
         //               new StudentCourse
         //               {
         //                   Course = new Course
         //                   {
         //                       Name = "C#",
         //                       MaxmumStrength = 12,
         //                       CreateTime = DateTime.Now,
         //                       ModifiedTime = DateTime.Now,
         //                   },
         //                       CreateTime = DateTime.Now,
         //                       ModifiedTime = DateTime.Now,
         //               }
         //           }


         //       };


             

         //    //   efDbContext.Students.Add(student);
         //       efDbContext.Students.Add(student);
         //       efDbContext.SaveChanges();
                
               

             
         //   }
    }
}
