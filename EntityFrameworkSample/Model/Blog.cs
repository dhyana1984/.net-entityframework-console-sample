using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Model
{
   public class Blog
    {
       public int Id { get; set; }
       public string BlogName { get; set; }

       public string BlogIntroduction { get; set; }
       public string Signature { get; set; }

       public string BlogUrl { get; set; }


    }
}
