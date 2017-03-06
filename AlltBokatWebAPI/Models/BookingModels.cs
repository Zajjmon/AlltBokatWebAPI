using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.Models
{
    public class BookingModels
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.EmailAddress)] // TO-DO lägg till REGEX-sträng för EMAIL
        public string CustomerEmail { get; set; }

        public string CustomerName { get; set; }


        public string description { get; set; }

       

        
        public virtual ApplicationUser ApplicationUser { get; set; }
        
        public virtual BookingTimeSlotModels bookingTimeSlot { get; set; }



    
}
}