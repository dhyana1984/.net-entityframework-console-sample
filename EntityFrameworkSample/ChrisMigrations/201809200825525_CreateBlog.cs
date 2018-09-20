namespace EntityFrameworkSample.ChrisMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogName", c => c.String(maxLength: 100));
            DropColumn("dbo.Blogs", "Name");
            DropColumn("dbo.Blogs", "Url");
            DropColumn("dbo.Blogs", "CreatedTime");
            DropColumn("dbo.Blogs", "Double");
            DropColumn("dbo.Blogs", "Float");
            DropColumn("dbo.Blogs", "Char");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Char", c => c.String(maxLength: 11, fixedLength: true, unicode: false));
            AddColumn("dbo.Blogs", "Float", c => c.Single(nullable: false));
            AddColumn("dbo.Blogs", "Double", c => c.Double(nullable: false));
            AddColumn("dbo.Blogs", "CreatedTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Blogs", "Url", c => c.String());
            AddColumn("dbo.Blogs", "Name", c => c.String(maxLength: 50));
            DropColumn("dbo.Blogs", "BlogName");
        }
    }
}
