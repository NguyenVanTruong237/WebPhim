using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPhim.Models;
using WebPhim.ViewModel;

namespace WebPhim.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }
        public ActionResult New()
        {
            var genreMovie = _context.GenreMovies.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genremovies = genreMovie
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel (movie)
            {                
                Genremovies = _context.GenreMovies.ToList()
            };
            return View("MovieForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            //if (movie.NumberAvailable != movie.NumberStock)
            //    return View("MovieForm", viewModel);
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel (movie)
                {                   
                    Genremovies = _context.GenreMovies.ToList()
                };
                return View("MovieForm",viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.SingleOrDefault(c => c.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.DateAdded = movie.DateAdded;
                movieInDB.RealeaseDate = movie.RealeaseDate;               
                movieInDB.GenreMovieId= movie.GenreMovieId;
                movieInDB.NumberStock = movie.NumberStock;
                movieInDB.NumberAvailable = movie.NumberAvailable;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        // GET: Movies
        public ViewResult Index()
        {           
            return View();
        }    
        //public ActionResult Details(int id)
        //{
        //    var movie = _context.Movies.Include(c => c.GenreMovie).SingleOrDefault(c => c.Id ==  id);
        //    if (movie == null)
        //    {
        //        return HttpNotFound();
        //    }           
        //    return View(movie);
        //}
    }
}