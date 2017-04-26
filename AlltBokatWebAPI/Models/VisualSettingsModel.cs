using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlltBokatWebAPI.Models
{
    [Table("VisualSettingsModels")]
    public class VisualSettingsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ThemeName { get; set; }
        public string BootStrapUrl { get; set; }
        public string PictureUrl { get; set; }
        public string StartText { get; set; }
    }
}