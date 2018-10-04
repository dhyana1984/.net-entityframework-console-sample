using EntityFrameworkSample.Entity;
using EntityFrameworkSample.EFLog;
using EntityFrameworkSample.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace EntityFrameworkSample
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            using(var db = new EfDbContext())
            using (var db1 = new EfDbContext())
            {
                var student = db.Students.FirstOrDefault(t=>t.Id==2);
                var student1 = db1.Students.FirstOrDefault(t => t.Id == 2);

                student.Name = "Chris1";
                db.SaveChanges();

                student1.Name = "Chris2";
              
              
                    
           
            }
            Console.ReadLine();
        }

        static Customer  GetCustomer()
        {
            var customer = new Customer()
            {
                Id = 1,
              CreateTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                Email = "aaa2@163.com",
           //     Name = "ChrisXiomg"

            };
            return customer;
        }    
    }
}
