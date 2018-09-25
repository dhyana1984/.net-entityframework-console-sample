namespace EntityFrameworkSample.ChrisMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomerSP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Customer_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 50, unicode: false),
                        Email = p.String(maxLength: 50, unicode: false),
                        CreateTime = p.DateTime(),
                        ModifiedTime = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Customers]([Name], [Email], [CreateTime], [ModifiedTime])
                      VALUES (@Name, @Email, @CreateTime, @ModifiedTime)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Customers]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Customers] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Customer_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(maxLength: 50, unicode: false),
                        Email = p.String(maxLength: 50, unicode: false),
                        CreateTime = p.DateTime(),
                        ModifiedTime = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Customers]
                      SET [Name] = @Name, [Email] = @Email, [CreateTime] = @CreateTime, [ModifiedTime] = @ModifiedTime
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Customer_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Customers]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Customer_Delete");
            DropStoredProcedure("dbo.Customer_Update");
            DropStoredProcedure("dbo.Customer_Insert");
        }
    }
}
