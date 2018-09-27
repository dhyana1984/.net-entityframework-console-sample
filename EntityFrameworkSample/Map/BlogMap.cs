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
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
       public BlogMap()
       {
           ToTable("Blogs");
           Property(t => t.Title).HasMaxLength(100);

       }
    }
}
