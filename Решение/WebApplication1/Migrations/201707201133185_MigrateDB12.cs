namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "ParentId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groups", "ParentId", c => c.Int(nullable: false));
        }
    }
}
