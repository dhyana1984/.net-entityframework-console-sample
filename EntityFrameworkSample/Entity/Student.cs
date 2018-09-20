using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Entity
{
  public  class Student:BaseEntity
    {
      public string Name { get; set; }
      public byte Age { get; set; }

      private string adress { get; set; }
      //隐式配置多对多
      //public virtual ICollection<Course> Courses { get; set; }

      //显示配置多对多
   //   public virtual ICollection<StudentCourse> StudentCourses { get; set; }

      public virtual StudentContract Contract { get; set; }
    }

    public class StudentContract
    {
        public long Id{get;set;}
        public string ContractNumber{get;set;}
        public virtual Student Student{get;set;}
    }


}
