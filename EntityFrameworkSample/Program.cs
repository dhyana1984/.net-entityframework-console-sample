using EntityFrameworkSample.Entity;
using EntityFrameworkSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EfDbContext())
            {

                Student student = new Student
                {
                    Name = "Jack",
                    Age = 22,
                    Contract = new StudentContract
                    {
                        ContractNumber="13333333333",
                        
                    }
                };



                db.Students.Add(student);
                db.SaveChanges();



            }

        }
    }
}
