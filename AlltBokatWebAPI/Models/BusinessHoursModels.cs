using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.Models
{
    [Table("BusinessHoursModels")]
    public class BusinessHoursModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string OpenAt { get; set; }
        public string CloseAt { get; set; }


    }
}