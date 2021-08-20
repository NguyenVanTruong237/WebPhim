using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPhim.Models
{
    public class Movie
    {
        public int Id { get; set; }    
        [Required]
        [StringLength(255)]
        public string Name { get; set; }       
        public DateTime RealeaseDate { get; set; }       
        public DateTime DateAdded { get; set; }       
        [Range(1,20)]
        public byte NumberStock { get; set; }
        public GenreMovie GenreMovie { get; set; }
        [Required]
        public int GenreMovieId { get; set; }
    }
}