using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Entity
{
   public class Employee:BaseEntity
    {

       public string Name { get; set; }
       public string PhoneNumber { get; set; }
       public string DetailAddress { get; set; }


       public virtual EmployeePhoto Photo { get; set; }
    }
}
