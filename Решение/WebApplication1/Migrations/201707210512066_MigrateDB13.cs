namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subgroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.GroupId);
            
            AddColumn("dbo.Employees", "Subgroup_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Subgroup_Id");
            AddForeignKey("dbo.Employees", "Subgroup_Id", "dbo.Subgroups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subgroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Employees", "Subgroup_Id", "dbo.Subgroups");
            DropIndex("dbo.Subgroups", new[] { "GroupId" });
            DropIndex("dbo.Employees", new[] { "Subgroup_Id" });
            DropColumn("dbo.Employees", "Subgroup_Id");
            DropTable("dbo.Subgroups");
        }
    }
}
