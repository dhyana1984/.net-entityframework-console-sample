using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkSample.Entity;

namespace EntityFrameworkSample.Map
{
   public class ClientMap: EntityTypeConfiguration<Entity.Client>
    {
       public ClientMap()
        {
            ToTable("Clients");

            HasKey(t => t.Id).Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            Property(t => t.Email).HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();

            HasMany(t => t.ClientSheets).WithRequired(t => t.Client).HasForeignKey(t => t.ClientId);
        }
    }
}
