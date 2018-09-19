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
    public class StudentsMap : EntityTypeConfiguration<Student>
    {
        public StudentsMap()
        {
            ToTable("Students");

            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Age);
            Property(t => t.CreateTime);
            Property(t => t.ModifiedTime);
            //隐士配置多对多关系，不用加StudentCourse Entity
            //HasMany(t => t.Courses).WithMany(c => c.Students).Map(t => t.ToTable("StudentCourses").MapLeftKey("StudentId").MapRightKey("CourseId"));//如果不设置左右键则用类名下划线加id

            //显示配置多对多，需要加StudentCourse Entity
          //  HasMany(m => m.StudentCourses).WithRequired(o => o.Student).HasForeignKey(k => k.StudentId);

            //学生也许没有联系方式，但是一个联系方式必须对应一个学生
            HasOptional(t => t.Contract).WithRequired(l => l.Student);
        }
    }

    public class StudentContractMap :EntityTypeConfiguration<StudentContract>
    {
        public StudentContractMap()
        {
            ToTable("StudentContacts");

            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("StudentId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
