namespace AlltBokatWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStartText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisualSettingsModels", "StartText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisualSettingsModels", "StartText");
        }
    }
}
