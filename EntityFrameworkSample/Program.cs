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

                //新建Model用来查询关联查询结果
                var customerInfo = db.Database.SqlQuery<CustomerInfo>("select c.Id, c.Name, c.Email,o.Price,o.Quanatity from Customers c " +
                    " join Orders o on c.id = o.customerid").ToList();

                //执行存储过程
                var customers = db.Database.SqlQuery<Customer>("SP_GetCustomers").ToList();
     




            }

        }
    }
}
