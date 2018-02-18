namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB14 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Subgroup_Id", newName: "SubgroupId");
            RenameIndex(table: "dbo.Employees", name: "IX_Subgroup_Id", newName: "IX_SubgroupId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Employees", name: "IX_SubgroupId", newName: "IX_Subgroup_Id");
            RenameColumn(table: "dbo.Employees", name: "SubgroupId", newName: "Subgroup_Id");
        }
    }
}
