using EntityFrameworkSample.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Map
{
    public class ClientSheetMap: EntityTypeConfiguration<ClientSheet>
    {
        public ClientSheetMap()
        {
            ToTable("ClientSheets");

            HasKey(t => t.Id).Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Quantity);
            Property(t => t.Price).HasPrecision(18, 4);
            Property(t => t.ClientId);
            Property(t => t.Code).HasMaxLength(400);
        }
    }
}
