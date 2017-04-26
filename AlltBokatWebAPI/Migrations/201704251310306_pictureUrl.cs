namespace AlltBokatWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pictureUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisualSettingsModels", "PictureUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisualSettingsModels", "PictureUrl");
        }
    }
}
