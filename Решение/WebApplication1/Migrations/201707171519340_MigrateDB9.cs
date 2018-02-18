namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "SectionId", c => c.Int());
            CreateIndex("dbo.Employees", "SectionId");
            AddForeignKey("dbo.Employees", "SectionId", "dbo.Sections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SectionId", "dbo.Sections");
            DropIndex("dbo.Employees", new[] { "SectionId" });
            DropColumn("dbo.Employees", "SectionId");
        }
    }
}
