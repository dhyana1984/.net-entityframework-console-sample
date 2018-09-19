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
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            ToTable("Courses");

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(t => t.MaxmumStrength);
            Property(t => t.CreateTime);
            Property(t => t.ModifiedTime);

            //现实配置多对多
            HasMany(t => t.StudentCourses).WithRequired(o => o.Course).HasForeignKey(k => k.CourseId);
        }
    }
}
