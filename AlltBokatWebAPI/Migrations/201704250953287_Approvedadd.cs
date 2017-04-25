namespace AlltBokatWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Approvedadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingModels", "Approved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingModels", "Approved");
        }
    }
}
