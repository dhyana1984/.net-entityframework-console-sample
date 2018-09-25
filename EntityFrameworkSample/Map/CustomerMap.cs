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
   public class CustomerMap:EntityTypeConfiguration<Customer>
    {
       public CustomerMap()
       {
           ToTable("Customers");

           HasKey(t => t.Id);

           Property(t => t.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
           Property(t => t.Email).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
           Property(t => t.CreateTime);
           Property(t => t.ModifiedTime);

            MapToStoredProcedures();//自动生成存储过程，需要迁移 
       }
    }
}
