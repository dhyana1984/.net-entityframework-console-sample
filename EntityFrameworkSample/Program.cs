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

namespace EntityFrameworkSample
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            using (var db = new EfDbContext())
            {
                //增加测试数据
                //var customer = new Customer
                //{
                //    Name = "Tom",
                //    Email = "Tom@163.com",
                //    Orders = new List<Order>
                //      {
                //         new Order
                //         {
                //              Quanatity=100,
                //               Price=12
                //         },
                //            new Order
                //         {
                //              Quanatity=120,
                //               Price=10
                //         }
                //      },
                //};
                //db.Customers.Add(customer);
                //db.SaveChanges();

                //var customer = GetCustomer();
                //var dbCustomer = db.Customers.FirstOrDefault(t => t.Id == customer.Id);
                //if(dbCustomer != null)
                //{
                //    //db.Customers.Attach(customer);
                //    //db.Entry(customer).State = EntityState.Modified;

                //    if (db.Entry(dbCustomer).State != EntityState.Unchanged)
                //        db.Entry(dbCustomer).State = EntityState.Unchanged;
                //    db.Entry(dbCustomer).CurrentValues.SetValues(customer);

                //    if (db.SaveChanges()>0)
                //    {
                //        Console.WriteLine("更新成功");
                //    }
                //    else
                //    {
                //        Console.WriteLine("更新失败");
                //    }

                //}

                // db.Database.Log = msg => MyLog.Log("EntityLoggingDemo", msg);
                //var sw = new StreamWriter(@"f:\ef.log") { AutoFlush = true };
                //db.Database.Log = s => { sw.Write(s); };
                db.Database.Log = s => logger.Error(s);
                var orders = db.Orders.Where(t => t.CustomerId == 1).ToList();
              



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
