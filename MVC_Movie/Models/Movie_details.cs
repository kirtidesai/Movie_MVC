using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Movie.Models
{
    public class Movie_details
    {
        [Key]
        [Column(Order = 1)]
        public int Movie_details_id { get; set; }
        public int Actor_Id { get; set; }
        public int Producer_Id { get; set; }
        public int Movie_Id { get; set; }

        public virtual actor Actor { get; set; }
        public virtual producer Producer { get; set; }
        public virtual movie Movie { get; set; }
    }
}