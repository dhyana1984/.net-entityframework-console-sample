using EntityFrameworkSample.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Model
{
    public class EfDbContext : DbContext
    {
        public EfDbContext()
            : base("name=ConnectionString")
        {
             
            //  Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfDbContext>());
         //  Configuration.LazyLoadingEnabled = false; //关闭延迟加载
           //Configuration.AutoDetectChangesEnabled = true;


            ////数据库不存在就创建
            //Database.SetInitializer(new CreateDatabaseIfNotExists<EfDbContext>());

            ////总是创建数据库，无论存在与否
            //Database.SetInitializer(new DropCreateDatabaseAlways<EfDbContext>());

            ////如果EF检测到数据库模型发生了改变，将更新模型
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //全局配置模型的Id作为主键
            //modelBuilder.Properties().Where(t => t.Name == "Id").Configure(config => config.IsKey());

            //自定义CustomerKeyConvention类作为自定义配置项
            modelBuilder.Conventions.Add<CustomerKeyConvention>();

            //注册Map类

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(types => !string.IsNullOrEmpty(types.Namespace))
                                  .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<StudentContract> StudentContracts { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Entity.Client> Clients { get; set; }
        public DbSet<ClientSheet> ClientSheets { get; set; }

    } 

    //自定义全局约定
    public class CustomerKeyConvention:Convention
    {
        public CustomerKeyConvention()
        {
            Properties().Where(t => t.Name == "Id").Configure(config => config.IsKey());
        }
    }
}
