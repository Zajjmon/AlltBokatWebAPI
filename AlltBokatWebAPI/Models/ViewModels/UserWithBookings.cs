using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.Models.ViewModels
{
    public class UserWithBookings
    {
        public ICollection<BookingModels> BookingModels { get; set; }
        public ApplicationUser User { get; set; }
    }
}