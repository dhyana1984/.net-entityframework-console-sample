using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Client
{
    class SqlQuery
    {
        //新建Model用来查询关联查询结果
        //var customerInfo = db.Database.SqlQuery<CustomerInfo>("select c.Id, c.Name, c.Email,o.Price,o.Quanatity from Customers c " +
        //    " join Orders o on c.id = o.customerid").ToList();

        //执行存储过程
        // var customers = db.Database.SqlQuery<Customer>("SP_GetCustomers").ToList();
    }
}
