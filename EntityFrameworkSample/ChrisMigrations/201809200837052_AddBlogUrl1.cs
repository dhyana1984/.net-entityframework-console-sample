namespace EntityFrameworkSample.ChrisMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogUrl1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogUrl", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "BlogUrl");
        }
    }
}
