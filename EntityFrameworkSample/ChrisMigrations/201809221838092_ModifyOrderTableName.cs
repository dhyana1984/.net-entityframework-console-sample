namespace EntityFrameworkSample.ChrisMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyOrderTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Oders", newName: "Orders");
            DropColumn("dbo.Orders", "comments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "comments", c => c.String());
            RenameTable(name: "dbo.Orders", newName: "Oders");
        }
    }
}
