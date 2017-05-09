using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.Models
{
    public class BookingTimeSlotModels
    {
        [Key]
        public int Id { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        
    }
}