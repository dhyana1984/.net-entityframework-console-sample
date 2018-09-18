using EntityFrameworkSample.Entity;
using EntityFrameworkSample.Model;
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
            using(var efDbContext = new EfDbContext())
            {
                //efDbContext.Blogs.Add(new Blog()
                //{
                //    Name = "Jeffky",
                //    Url = "http://www.163.com"

                //});
                //var user = efDbContext.Users.Find(1);

                //var originalValues = efDbContext.Entry(user).ComplexProperty(t => t.Address).OriginalValue;
                //var currentValues = efDbContext.Entry(user).ComplexProperty(t => t.Address).CurrentValue;
                var customer = new Customer()
                {
                    Name = "Chris",
                    Email = "aaa@aa.com",
                    CreateTime = DateTime.Now,
                    ModifiedTime = DateTime.Now,
                    Orders = new List<Order>
                   {
                       new Order
                       {
                            Quanatity=12,
                            Price=1500,
                            CreateTime=DateTime.Now,
                            ModifiedTime=DateTime.Now
                       },
                       new Order
                       {
                            Quanatity=10,
                            Price=2500,
                            CreateTime=DateTime.Now,
                            ModifiedTime=DateTime.Now
                       }
                   }
                };
                efDbContext.Customers.Add(customer);
                efDbContext.SaveChanges();
               

             
            }
        }
    }
}
