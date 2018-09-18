using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Model
{
  public  class User
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public DateTime BirthDate {get;set;}
      public string IDNumber { get; set; }
      public Address Address { get; set; }
      public DateTime? CreatedTime { get; set; }
      public DateTime? ModifiedTime { get; set; }
    }
}
