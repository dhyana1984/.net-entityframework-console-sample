using EntityFrameworkSample.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Map
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        
      public EmployeeMap()
      {
          //实体拆分，把Employee表拆成2个表，在查询Employee时，生成的SQL会自动关联查询两个表，插入时，EF会生成两个表的插入语句
          //Map(map =>
          //      {
          //          map.Properties(t => new
          //              {
          //                  t.Id,
          //                  t.Name,
          //                  t.CreateTime,
          //                  t.ModifiedTime
          //              });
          //          map.ToTable("Employees");
          //      }).Map(map =>
          //      {
          //          map.Properties(t => new
          //          {
          //              t.PhoneNumber,
          //              t.DetailAddress
          //          });
          //          map.ToTable("EmployeeDetails");
          //      });


          //将Employee和EmployeePhoto 2个实体映射到同一个表,查找Employee时不会加载EmployeePhoto，Include的时候才会加载
          ToTable("Employees");
          HasKey(t => t.Id);
          HasRequired(t => t.Photo).WithRequiredPrincipal(t => t.Employee);
             
      }
    }

    public class EmployePhotoMap :EntityTypeConfiguration<EmployeePhoto>
    {
        public EmployePhotoMap()
        {
            ToTable("Employees");
            HasKey(t => t.Id);
        }
    }
}
