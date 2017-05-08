namespace AlltBokatWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessHoursModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpenAt = c.String(),
                        CloseAt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BusinessHoursModels");
        }
    }
}
