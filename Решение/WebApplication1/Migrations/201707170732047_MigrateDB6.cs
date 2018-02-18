namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "GroupId", c => c.Int());
            CreateIndex("dbo.Employees", "GroupId");
            AddForeignKey("dbo.Employees", "GroupId", "dbo.Groups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "GroupId", "dbo.Groups");
            DropIndex("dbo.Employees", new[] { "GroupId" });
            DropColumn("dbo.Employees", "GroupId");
        }
    }
}
