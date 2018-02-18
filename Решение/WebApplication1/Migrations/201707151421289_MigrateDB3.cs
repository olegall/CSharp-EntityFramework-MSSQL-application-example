namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AdministrationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administrations", t => t.AdministrationId)
                .Index(t => t.AdministrationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "AdministrationId", "dbo.Administrations");
            DropIndex("dbo.Groups", new[] { "AdministrationId" });
            DropTable("dbo.Groups");
        }
    }
}
