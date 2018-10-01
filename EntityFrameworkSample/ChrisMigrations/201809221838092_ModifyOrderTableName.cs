namespace EntityFrameworkSample.ChrisMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyOrderTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Oders", newName: "Orders");
          
        }
        
        public override void Down()
        {
           
            RenameTable(name: "dbo.Orders", newName: "Oders");
        }
    }
}
