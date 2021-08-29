using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPhim.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
        [Required]
        public DateTime DateRented { get; set; }
        [Required]
        public DateTime? DateReturned { get; set; }
    }
}