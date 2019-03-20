using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Movie.Models
{
    public class actor
    {
        [Key]
        public int Actor_Id { get; set; }
        [Required]
        public string Actor_name { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public DateTime Date_Of_Birth { get; set; }
        [Required]
        public string Bio { get; set; }
    }
}