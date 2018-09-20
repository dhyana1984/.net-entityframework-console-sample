using EntityFrameworkSample.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Map
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
       public BlogMap()
       {
           ToTable("Blogs");
           Property(t => t.BlogName).HasMaxLength(100);
           Property(t => t.Signature).HasMaxLength(50);
           Property(t => t.BlogIntroduction).HasMaxLength(100);
           Property(t => t.BlogUrl).HasMaxLength(100);
       }
    }
}
