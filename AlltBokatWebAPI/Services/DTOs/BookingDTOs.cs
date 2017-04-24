using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.Services.DTOs
{
    public class BookingDTOs
    {
        public class BookingRequestDTO
        {
            public int Id { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerName { get; set; }
            public string Description { get; set; }
            public string ApplicationUserId { get; set; }
            public bool Approved { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }

        }

        public class SingleBookingDTO
        {
            public int Id { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string CustomerName { get; set; }
            public string CustomerEmail { get; set; }
            public string Description { get; set; }
            public bool Approved { get; set; }
            public string ApplicationUserFirstName { get; set; }
            public string ApplicationUserLastName { get; set; }

        }

        


    }
}