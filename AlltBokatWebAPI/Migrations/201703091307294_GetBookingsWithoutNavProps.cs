namespace AlltBokatWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetBookingsWithoutNavProps : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BookingModels", "SimonsTextTest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingModels", "SimonsTextTest", c => c.String());
        }
    }
}
