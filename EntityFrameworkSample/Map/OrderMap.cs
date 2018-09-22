using EntityFrameworkSample.Entity;
using EntityFrameworkSample.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Map
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Orders");
            HasKey(t => t.Id);

            Property(t => t.Quanatity);
            Property(t => t.Price);
            Property(t => t.CustomerId);
            Property(t => t.CreateTime);
            Property(t => t.ModifiedTime);

            HasRequired(t => t.Customer).WithMany(c => c.Orders).HasForeignKey(t => t.CustomerId).WillCascadeOnDelete(false);

        }
    }
}
