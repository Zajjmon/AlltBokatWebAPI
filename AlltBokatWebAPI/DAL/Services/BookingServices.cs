using AlltBokatWebAPI.Models;
using AlltBokatWebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AlltBokatWebAPI.Models.ViewModels.BookingViewModels;

namespace AlltBokatWebAPI.DAL.Services
{
    public class BookingServices
    {


        //Converts a List of BookingModels to  a list of BookingsWithoutNavProps 
        public List<BookingInfoViewModelWithId> ConvertToBookingWithoutNavProps(IQueryable<BookingModels> x)
        {
            var BookingInfoViewModelWithIdList = new List<BookingInfoViewModelWithId>();

            var FullBookingList= x.ToList();


            foreach (BookingModels item in FullBookingList)
            {

                BookingInfoViewModelWithId BookingInfoViewModelWithId = new BookingInfoViewModelWithId();



                BookingInfoViewModelWithId.Id = item.BookingTimeSlotModels.Id;
                BookingInfoViewModelWithId.ApplicationUserId = item.ApplicationUserId;
                BookingInfoViewModelWithId.CustomerEmail = item.CustomerEmail;
                BookingInfoViewModelWithId.CustomerName = item.CustomerName;
                BookingInfoViewModelWithId.description = item.description;
                BookingInfoViewModelWithId.startTime = item.BookingTimeSlotModels.startTime;
                BookingInfoViewModelWithId.endTime = item.BookingTimeSlotModels.endTime;
                BookingInfoViewModelWithId.UserName = item.ApplicationUser.UserName;
                BookingInfoViewModelWithIdList.Add(BookingInfoViewModelWithId);


            }

            return BookingInfoViewModelWithIdList;
        }

        public BookingInfoViewModelWithId ConvertToSingleBookingInfoViewModelWithId(BookingModels bookingModel)
        {
            
            var singleBooking = new BookingInfoViewModelWithId
            {
                Id = bookingModel.Id,
                ApplicationUserId = bookingModel.ApplicationUserId,
                CustomerEmail = bookingModel.CustomerEmail,
                CustomerName = bookingModel.CustomerName,
                description = bookingModel.description,
                startTime = bookingModel.BookingTimeSlotModels.startTime,
                endTime = bookingModel.BookingTimeSlotModels.endTime,
                UserName = bookingModel.ApplicationUser.UserName

            };
            return singleBooking;

        }













    }
}