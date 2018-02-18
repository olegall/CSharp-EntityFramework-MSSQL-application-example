namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB10 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Group_Id", newName: "GroupId");
            RenameIndex(table: "dbo.Employees", name: "IX_Group_Id", newName: "IX_GroupId");
            AddColumn("dbo.Groups", "Administration_Id", c => c.Int());
            CreateIndex("dbo.Groups", "Administration_Id");
            AddForeignKey("dbo.Groups", "Administration_Id", "dbo.Administrations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "Administration_Id", "dbo.Administrations");
            DropIndex("dbo.Groups", new[] { "Administration_Id" });
            DropColumn("dbo.Groups", "Administration_Id");
            RenameIndex(table: "dbo.Employees", name: "IX_GroupId", newName: "IX_Group_Id");
            RenameColumn(table: "dbo.Employees", name: "GroupId", newName: "Group_Id");
        }
    }
}
