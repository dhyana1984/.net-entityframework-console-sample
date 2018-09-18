﻿using EntityFrameworkSample.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Model
{
    public class EfDbContext : DbContext
    {
        public EfDbContext():base("name=ConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().Property(t => t.Name).HasMaxLength(50);
            modelBuilder.Entity<Blog>().Property(t => t.Char).HasColumnType("char").HasMaxLength(11);
            modelBuilder.Entity<Blog>().Property(t => t.CreatedTime).HasColumnType("DATETIME2");
       

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
    }
}