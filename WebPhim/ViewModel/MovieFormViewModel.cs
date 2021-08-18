using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPhim.Models;

namespace WebPhim.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreMovie> Genremovies { get; set; }
        public Movie Movie { get; set; }
    }
}