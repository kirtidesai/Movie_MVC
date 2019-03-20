using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Movie.Models
{
    public class producer
    {
        [Key]
        public int Producer_Id { get; set; }
        [Required]
        public string Producer_name { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public DateTime Date_Of_Birth { get; set; }
        [Required]
        public string Bio { get; set; }
    }
}