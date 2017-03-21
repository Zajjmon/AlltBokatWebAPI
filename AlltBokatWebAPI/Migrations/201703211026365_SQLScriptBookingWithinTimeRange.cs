namespace AlltBokatWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLScriptBookingWithinTimeRange : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.SelectUsersWithBookingWithinTimeRange",
                p => new
                    {
                    inputStartTime = p.DateTime(),
                    inputEndTime = p.DateTime(),
                    },

                body:
                    @"
                    SELECT [dbo].[AspNetUsers].* FROM [dbo].[AspNetUsers]
                    JOIN [dbo].[BookingModels] ON [dbo].[AspNetUsers].Id = [dbo].[BookingModels].ApplicationUserId
                    JOIN [dbo].[BookingTimeSlotModels] ON [dbo].[BookingModels].BookingTimeSlotModelsId = [dbo].[BookingTimeSlotModels].Id
                    WHERE @inputStartTime <= [endTime] AND [startTime] <= @inputEndTime"
                                );

            CreateStoredProcedure(
                "dbo.SelectUsersWithBookingNOTWithinTimeRange",
                p => new
                {
                    inputStartTime = p.DateTime(),
                    inputEndTime = p.DateTime(),
                },

            body:
                @"
                SELECT AspNetUsers.* FROM AspNetUsers
                WHERE AspNetUsers.Id not in 
                (SELECT AspNetUsers.Id FROM AspNetUsers
                JOIN BookingModels ON AspNetUsers.Id = BookingModels.ApplicationUserId
                JOIN BookingTimeSlotModels ON BookingModels.BookingTimeSlotModelsId = BookingTimeSlotModels.Id 
                WHERE @inputStartTime <= endTime AND  startTime <= @inputEndTime)"
                                );
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.SelectUsersWithBookingWithinTimeRange");
            DropStoredProcedure("dbo.SelectUsersWithBookingNOTWithinTimeRange");
        }
    }
}
