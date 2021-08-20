using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebPhim.Models;

namespace WebPhim.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreMovie> Genremovies { get; set; }
        public int? Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên phim.")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nhập ngày thêm")]
        public DateTime? DateAdded { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày công chiếu")]
        public DateTime? RealeaseDate { get; set; }       
        [Required(ErrorMessage = "Vui lòng nhập số lượng trong kho.")]
        [Range(1, 20)]
        public byte? NumberStock { get; set; }       
        [Required(ErrorMessage = "Vui lòng chọn thể loại.")]
        public int? GenreMovieId { get; set; }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {            
            Id = movie.Id;
            Name = movie.Name;
            RealeaseDate = movie.RealeaseDate;
            NumberStock = movie.NumberStock;
            GenreMovieId = movie.GenreMovieId;
            DateAdded = movie.DateAdded;
        }
    }
}