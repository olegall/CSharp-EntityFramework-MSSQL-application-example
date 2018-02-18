namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "AdministrationId", "dbo.Administrations");
            DropIndex("dbo.Groups", new[] { "AdministrationId" });
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AdministrationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administrations", t => t.AdministrationId)
                .Index(t => t.AdministrationId);
            
            AddColumn("dbo.Groups", "SectionId", c => c.Int());
            CreateIndex("dbo.Groups", "SectionId");
            AddForeignKey("dbo.Groups", "SectionId", "dbo.Sections", "Id");
            DropColumn("dbo.Groups", "AdministrationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "AdministrationId", c => c.Int());
            DropForeignKey("dbo.Groups", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Sections", "AdministrationId", "dbo.Administrations");
            DropIndex("dbo.Groups", new[] { "SectionId" });
            DropIndex("dbo.Sections", new[] { "AdministrationId" });
            DropColumn("dbo.Groups", "SectionId");
            DropTable("dbo.Sections");
            CreateIndex("dbo.Groups", "AdministrationId");
            AddForeignKey("dbo.Groups", "AdministrationId", "dbo.Administrations", "Id");
        }
    }
}
