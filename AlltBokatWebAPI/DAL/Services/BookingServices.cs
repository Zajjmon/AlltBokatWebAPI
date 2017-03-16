using AlltBokatWebAPI.Models;
using AlltBokatWebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.DAL.Services
{
    public class BookingServices
    {


        //Converts a List of BookingModels to  a list of BookingsWithoutNavProps 
        public List<BookingWithoutNavProp> ConvertToBookingWithoutNavProps(IQueryable<BookingModels> x)
        {
            var BookingWithoutNavPropBookingList = new List<BookingWithoutNavProp>();

            var FullBookingList= x.ToList();


            foreach (BookingModels item in FullBookingList)
            {

                BookingWithoutNavProp bookingWithOutNavProp = new BookingWithoutNavProp();



                bookingWithOutNavProp.Id = item.BookingTimeSlotModels.Id;
                bookingWithOutNavProp.ApplicationUserId = item.ApplicationUserId;
                bookingWithOutNavProp.CustomerEmail = item.CustomerEmail;
                bookingWithOutNavProp.CustomerName = item.CustomerName;
                bookingWithOutNavProp.description = item.description;
                bookingWithOutNavProp.startTime = item.BookingTimeSlotModels.startTime;
                bookingWithOutNavProp.endTime = item.BookingTimeSlotModels.endTime;
                bookingWithOutNavProp.UserName = item.ApplicationUser.UserName;
                BookingWithoutNavPropBookingList.Add(bookingWithOutNavProp);


            }

            return BookingWithoutNavPropBookingList;
        }















    }
}