using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Entity
{
  public  class Course: BaseEntity
    {
      public string Name { get; set; }
      public int MaxmumStrength { get; set; }

      //隐式配置多对多
      //public virtual ICollection<Student> Students { get; set; }

      //显示配置多对多
      public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
