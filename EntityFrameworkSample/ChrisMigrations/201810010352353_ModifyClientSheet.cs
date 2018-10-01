namespace EntityFrameworkSample.ChrisMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyClientSheet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClientSheets", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientSheets", "Quantity", c => c.String());
        }
    }
}
