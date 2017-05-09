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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)] 
        public string CustomerEmail { get; set; }
        public string CustomerName { get; set; }
        public string description { get; set; }
        public string ApplicationUserId { get; set; }
        public Boolean Approved { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("BookingTimeSlotModels")]
        public int BookingTimeSlotModelsId { get; set; }
        public virtual BookingTimeSlotModels BookingTimeSlotModels { get; set; }




    }
}