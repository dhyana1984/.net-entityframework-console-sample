namespace EntityFrameworkSample.ChrisMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientAndClientSheet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientSheets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Quantity = c.String(),
                        Code = c.String(maxLength: 400),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 4),
                        ClientId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientSheets", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientSheets", new[] { "ClientId" });
            DropTable("dbo.ClientSheets");
            DropTable("dbo.Clients");
        }
    }
}
