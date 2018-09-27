namespace EntityFrameworkSample.ChrisMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            AddColumn("dbo.Blogs", "Title", c => c.String(maxLength: 100));
            DropColumn("dbo.Blogs", "BlogName");
            DropColumn("dbo.Blogs", "BlogIntroduction");
            DropColumn("dbo.Blogs", "Signature");
            DropColumn("dbo.Blogs", "BlogUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogUrl", c => c.String(maxLength: 100));
            AddColumn("dbo.Blogs", "Signature", c => c.String(maxLength: 50));
            AddColumn("dbo.Blogs", "BlogIntroduction", c => c.String(maxLength: 100));
            AddColumn("dbo.Blogs", "BlogName", c => c.String(maxLength: 100));
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Posts", new[] { "BlogId" });
            DropColumn("dbo.Blogs", "Title");
            DropTable("dbo.Posts");
        }
    }
}
