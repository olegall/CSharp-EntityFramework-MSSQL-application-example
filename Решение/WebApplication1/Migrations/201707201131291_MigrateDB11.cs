namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "ParentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "ParentId");
        }
    }
}
