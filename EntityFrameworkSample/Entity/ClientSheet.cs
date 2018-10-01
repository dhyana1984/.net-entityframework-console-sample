using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Entity
{
   public class ClientSheet
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
