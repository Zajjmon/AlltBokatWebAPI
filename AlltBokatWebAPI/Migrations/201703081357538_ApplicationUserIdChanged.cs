namespace AlltBokatWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserIdChanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BookingModels", name: "UserId", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.UserRatingModels", name: "UserId", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.BookingModels", name: "IX_UserId", newName: "IX_ApplicationUserId");
            RenameIndex(table: "dbo.UserRatingModels", name: "IX_UserId", newName: "IX_ApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserRatingModels", name: "IX_ApplicationUserId", newName: "IX_UserId");
            RenameIndex(table: "dbo.BookingModels", name: "IX_ApplicationUserId", newName: "IX_UserId");
            RenameColumn(table: "dbo.UserRatingModels", name: "ApplicationUserId", newName: "UserId");
            RenameColumn(table: "dbo.BookingModels", name: "ApplicationUserId", newName: "UserId");
        }
    }
}
