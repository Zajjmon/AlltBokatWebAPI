namespace AlltBokatWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisualSettingsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BootStrapUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VisualSettingsModels");
        }
    }
}
