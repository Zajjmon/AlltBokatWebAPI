namespace AlltBokatWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookIngModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingModels", "CustomerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingModels", "CustomerName");
        }
    }
}
