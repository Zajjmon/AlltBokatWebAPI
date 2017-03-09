using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlltBokatWebAPI.Models;
using AlltBokatWebAPI.Models.ViewModels;

//namespace AlltBokatWebAPI.DAL
//{
//    public static class BookingDAL
//    {
//        public static List<BookingWithoutNavProp> GetAllBookingsWithoutNavProps()
//        {
//            using (var db = new ApplicationDbContext())
//            {
//                List<BookingWithoutNavProp> returnableBookings = new List<BookingWithoutNavProp>();
//                IQueryable<BookingModels> bookings = db.Bookings.AsQueryable();
//                foreach (var item in bookings)
//                {

//                    returnableBookings.Add(new BookingWithoutNavProp
//                    {
//                        Id = item.Id,
//                        ApplicationUserId = item.ApplicationUserId,
//                        BookingTimeSlotModelsId = item.BookingTimeSlotModelsId,
//                        CustomerEmail = item.CustomerEmail,
//                        CustomerName = item.CustomerName,
//                        description = item.description
//                    });

//                }
//                return returnableBookings;
//            }
//        }
//    }
//}
namespace AlltBokatWebAPI.DAL
{
    public static class BookingDAL
    {
        public static List<BookingWithoutNavProp> GetAllBookingsWithoutNavProps()
        {
            using (var db = new ApplicationDbContext())
            {
                List<BookingWithoutNavProp> returnableBookings = new List<BookingWithoutNavProp>();
                IQueryable<BookingModels> bookings = db.Bookings.AsQueryable();
                List<BookingModels> bookingsList = bookings.ToList();
                foreach (var item in bookingsList)
                {
                    ApplicationUser User = db.Users.Find(item.ApplicationUserId);
                    BookingTimeSlotModels timeSlot = db.BookingTimeSlots.Find(item.BookingTimeSlotModelsId);
                    returnableBookings.Add(new BookingWithoutNavProp
                    {
                        Id = item.Id,
                        ApplicationUserId = item.ApplicationUserId,
                        CustomerEmail = item.CustomerEmail,
                        CustomerName = item.CustomerName,
                        description = item.description,
                        startTime = timeSlot.startTime,
                        endTime = timeSlot.endTime,
                        UserName = User.UserName
                        
                    });

                }
                return returnableBookings;
            }
        }
    }
}