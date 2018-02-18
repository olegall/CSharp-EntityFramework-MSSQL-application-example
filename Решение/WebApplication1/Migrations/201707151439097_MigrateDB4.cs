namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Groups", name: "AdministrationId", newName: "Administration_Id");
            RenameIndex(table: "dbo.Groups", name: "IX_AdministrationId", newName: "IX_Administration_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Groups", name: "IX_Administration_Id", newName: "IX_AdministrationId");
            RenameColumn(table: "dbo.Groups", name: "Administration_Id", newName: "AdministrationId");
        }
    }
}
