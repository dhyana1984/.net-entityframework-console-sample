using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Entity
{
  public  class BaseEntity
    {
      public int Id { set; get; }
      public DateTime CreateTime { get; set; }
      public DateTime ModifiedTime { get; set; }
    }
}
