namespace EntityFrameworkSample.ChrisMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogIntroduction", c => c.String(maxLength: 100));
            AddColumn("dbo.Blogs", "BlogUrl", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "BlogUrl");
            DropColumn("dbo.Blogs", "BlogIntroduction");
        }
    }
}
