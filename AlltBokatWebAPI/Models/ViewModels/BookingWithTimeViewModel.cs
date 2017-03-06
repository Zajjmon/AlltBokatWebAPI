using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.Models.ViewModels
{
    public class BookingWithTimeViewModel
    {
        public BookingModels BookingModel { get; set; }
        public BookingTimeSlotModels BookingTimeSlotModel { get; set; }



    }
}