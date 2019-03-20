using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Movie.Models
{
    public class KeepDB : DbContext
    {
        public DbSet<actor> actors { get; set; }
        public DbSet<producer> producers { get; set; }
        public DbSet<movie> movie { get; set; }
        public DbSet<Movie_details> Movie_Details { get; set; }
    }
}