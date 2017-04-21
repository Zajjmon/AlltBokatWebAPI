namespace AlltBokatWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _60 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Hour", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "Minutes", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Duration", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "Minutes");
            DropColumn("dbo.Categories", "Hour");
        }
    }
}
