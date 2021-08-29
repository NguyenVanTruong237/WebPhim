using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using WebPhim.App_Start;
using WebPhim.Dtos;
using WebPhim.Models;

namespace WebPhim.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        private IMapper iMapper;
        private MapperConfiguration config;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
            config = new AutoMapperConfiguration().Configure();
            iMapper = config.CreateMapper();
        }
        //GET api/movies
        public IHttpActionResult GetMovies (string query = null)
        {
            var queryMovies = _context.Movies
                .Include(m => m.GenreMovie)
                .Where(m => m.NumberAvailable > 0);
            if (!string.IsNullOrWhiteSpace(query))
                queryMovies = queryMovies.Where(c => c.Name.Contains(query));
            var moviesDto = queryMovies.ToList().Select(iMapper.Map<Movie, MovieDto>);
            return Ok(moviesDto);
        }
        //GET api/movies/1
        public IHttpActionResult Getmovie (int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie ==  null)
            {
                NotFound();
            }
            return Ok(iMapper.Map<Movie, MovieDto>(movie));
        }
        //POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie (MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();
            var movie = iMapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        //PUT api/movies/1
        [HttpPut]
        public void UpdateMovie (int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDB = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            iMapper.Map(movieDto, movieInDB);
            _context.SaveChanges();
        }
        //DELETE api/movies/1
        [HttpDelete]
        public void DeleteMovie (int id)
        {
           var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null )
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
