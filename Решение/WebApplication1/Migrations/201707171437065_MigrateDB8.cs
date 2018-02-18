namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "GroupId", newName: "Group_Id");
            RenameIndex(table: "dbo.Employees", name: "IX_GroupId", newName: "IX_Group_Id");
            AddColumn("dbo.Employees", "AdministrationId", c => c.Int());
            CreateIndex("dbo.Employees", "AdministrationId");
            AddForeignKey("dbo.Employees", "AdministrationId", "dbo.Administrations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "AdministrationId", "dbo.Administrations");
            DropIndex("dbo.Employees", new[] { "AdministrationId" });
            DropColumn("dbo.Employees", "AdministrationId");
            RenameIndex(table: "dbo.Employees", name: "IX_Group_Id", newName: "IX_GroupId");
            RenameColumn(table: "dbo.Employees", name: "Group_Id", newName: "GroupId");
        }
    }
}
