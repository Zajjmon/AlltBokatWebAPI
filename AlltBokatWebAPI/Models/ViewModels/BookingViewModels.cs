using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.Models.ViewModels
{
    public class BookingViewModels
    {
        public class BookingInfoViewModelWithId
        {

            public int Id { get; set; }


            public string CustomerEmail { get; set; }

            public string CustomerName { get; set; }


            public string description { get; set; }

            public DateTime startTime { get; set; }
            public DateTime endTime { get; set; }

            public string UserName { get; set; }

            // foreign keys

            public string ApplicationUserId { get; set; }
        }

        public class BookingInfoViewModel
        {

            public string CustomerEmail { get; set; }

            public string CustomerName { get; set; }


            public string description { get; set; }

            public DateTime startTime { get; set; }
            public DateTime endTime { get; set; }

            public string UserName { get; set; }

            // foreign keys

            public string ApplicationUserId { get; set; }
        }













    }
}