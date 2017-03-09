using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.Models
{
    public class UserRatingModels
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; }


        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}