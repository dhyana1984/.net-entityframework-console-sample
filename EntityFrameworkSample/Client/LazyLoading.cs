using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Client
{
    class LazyLoading
    {
        ////避免序列化的时候循环序列化，Customer里面有Order，Order里面有Customer，用投影解决该问题
        //var transferCustomer = new Customer()
        //{
        //    CreateTime = customers.CreateTime,
        //    Email = customers.Email,
        //    ModifiedTime = customers.ModifiedTime,
        //    Name = customers.Name,
        //    Orders = customers.Orders.Select(t => new Order()
        //    {
        //        CreateTime = t.CreateTime,
        //        Id = t.Id,
        //        ModifiedTime = t.ModifiedTime,
        //        Price = t.Price,
        //        Quanatity = t.Quanatity
        //    }).ToList()

        //};
        //var serializeCustmer = JsonConvert.SerializeObject(transferCustomer);



        //var customer = db.Customers.FirstOrDefault();

        //饥饿加载
        //var customers = db.Customers.Include("Orders").FirstOrDefault();


        //在关闭延迟加载的基础上显示加载
        //db.Entry(customer).Collection(t => t.Orders).Load();
        //var orders = customer.Orders;
        //或者用Query
        //var orders = db.Entry(customer).Collection(t => t.Orders).Query().ToList();
    }
}
