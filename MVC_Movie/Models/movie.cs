using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Movie.Models
{
    public class movie
    {
        
        [Key]
        public int Movie_Id { get; set; }
        [Required]
        public string Movie_name { get; set; }
        [Required]
        public string Plot { get; set; }
        [Required]
        public DateTime Date_Of_Release { get; set; }

        public virtual ICollection<Movie_details> Movie_Details { get; set; }
    }
}