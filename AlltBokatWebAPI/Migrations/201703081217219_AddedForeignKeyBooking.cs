namespace AlltBokatWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyBooking : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingModels", "Id", "dbo.BookingTimeSlotModels");
            DropPrimaryKey("dbo.UserRatingModels");
            DropPrimaryKey("dbo.BookingTimeSlotModels");
            DropColumn("dbo.UserRatingModels", "UserRatingId");
            DropColumn("dbo.BookingTimeSlotModels", "bookingTimeSlotId");
            AddColumn("dbo.BookingModels", "bookingTimeSlotId", c => c.Int(nullable: false));
            AddColumn("dbo.UserRatingModels", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BookingTimeSlotModels", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BookingTimeSlotModels", "BookingModelId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserRatingModels", "Id");
            AddPrimaryKey("dbo.BookingTimeSlotModels", "Id");
            AddForeignKey("dbo.BookingModels", "Id", "dbo.BookingTimeSlotModels", "Id");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingTimeSlotModels", "bookingTimeSlotId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserRatingModels", "UserRatingId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.BookingModels", "Id", "dbo.BookingTimeSlotModels");
            DropPrimaryKey("dbo.BookingTimeSlotModels");
            DropPrimaryKey("dbo.UserRatingModels");
            DropColumn("dbo.BookingTimeSlotModels", "BookingModelId");
            DropColumn("dbo.BookingTimeSlotModels", "Id");
            DropColumn("dbo.UserRatingModels", "Id");
            DropColumn("dbo.BookingModels", "bookingTimeSlotId");
            AddPrimaryKey("dbo.BookingTimeSlotModels", "bookingTimeSlotId");
            AddPrimaryKey("dbo.UserRatingModels", "UserRatingId");
            AddForeignKey("dbo.BookingModels", "Id", "dbo.BookingTimeSlotModels", "bookingTimeSlotId");
        }
    }
}
