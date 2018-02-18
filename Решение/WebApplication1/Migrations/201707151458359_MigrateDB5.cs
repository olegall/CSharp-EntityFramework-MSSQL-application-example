namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Groups", name: "Administration_Id", newName: "AdministrationId");
            RenameIndex(table: "dbo.Groups", name: "IX_Administration_Id", newName: "IX_AdministrationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Groups", name: "IX_AdministrationId", newName: "IX_Administration_Id");
            RenameColumn(table: "dbo.Groups", name: "AdministrationId", newName: "Administration_Id");
        }
    }
}
