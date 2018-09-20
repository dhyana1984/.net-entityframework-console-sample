namespace EntityFrameworkSample.ChrisMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RMBlogUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Signature", c => c.String(maxLength: 50));
            DropColumn("dbo.Blogs", "BlogUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogUrl", c => c.String(maxLength: 50));
            DropColumn("dbo.Blogs", "Signature");
        }
    }
}
