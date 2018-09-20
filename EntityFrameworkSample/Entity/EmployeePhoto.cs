using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Entity
{
   public class EmployeePhoto
    {
       public int Id { get; set; }
       public byte[] Photo { get; set; }
       public Employee Employee { get; set; }
    }
}
