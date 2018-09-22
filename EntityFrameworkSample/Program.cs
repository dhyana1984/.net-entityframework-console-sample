using EntityFrameworkSample.Entity;
using EntityFrameworkSample.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EfDbContext())
            {

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

                var customer = db.Customers.FirstOrDefault();

                //避免序列化的时候循环序列化，Customer里面有Order，Order里面有Customer，用投影解决该问题
                var transferCustomer = new Customer()
                {
                    CreateTime = customer.CreateTime,
                    Email = customer.Email,
                    ModifiedTime = customer.ModifiedTime,
                    Name = customer.Name,
                    Orders = customer.Orders.Select(t => new Order()
                    {
                        CreateTime = t.CreateTime,
                        Id = t.Id,
                        ModifiedTime = t.ModifiedTime,
                        Price = t.Price,
                        Quanatity = t.Quanatity
                    }).ToList()

                };
                var serializeCustmer = JsonConvert.SerializeObject(transferCustomer);



            }

        }
    }
}
