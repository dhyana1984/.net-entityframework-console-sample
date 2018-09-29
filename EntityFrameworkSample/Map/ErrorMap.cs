using EntityFrameworkSample.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Map
{
   public class ErrorMap: EntityTypeConfiguration<Error>
    {
        public ErrorMap()
        {
            ToTable("Errors");

            HasKey(k => k.ErrorId);
            Property(p => p.Active);
            Property(p => p.CommandType).HasColumnType("VARCHAR");
            Property(p => p.CreateDate);
            Property(p => p.Exception).HasColumnType("VARCHAR");
            Property(p => p.FileName);
            Property(p => p.InnerException).HasColumnType("VARCHAR");
            Property(p => p.Parameters);
            Property(p => p.Query).IsRequired().HasColumnType("VARCHAR");
            Property(p => p.RequireId);
            Property(p => p.TotalSeconds);
        }
    }
}
