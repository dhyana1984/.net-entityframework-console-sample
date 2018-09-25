namespace EntityFrameworkSample.ChrisMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyCreteTimeModifyTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Courses", "ModifiedTime", c => c.DateTime());
            AlterColumn("dbo.StudentCourses", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.StudentCourses", "ModifiedTime", c => c.DateTime());
            AlterColumn("dbo.Students", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Students", "ModifiedTime", c => c.DateTime());
            AlterColumn("dbo.Customers", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Customers", "ModifiedTime", c => c.DateTime());
            AlterColumn("dbo.Orders", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Orders", "ModifiedTime", c => c.DateTime());
            AlterColumn("dbo.Employees", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Employees", "ModifiedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentCourses", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentCourses", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Courses", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Courses", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
