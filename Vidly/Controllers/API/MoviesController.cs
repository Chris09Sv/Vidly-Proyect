using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.App_Start;
using System.Data.Entity;

using AutoMapper;
using Vidly.Dtos;
namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //get/api/movie
        public IHttpActionResult GetMovies()
        {
            var moviesDto = _context.movies.Include(c =>c.Genre)
                .ToList().Select(Mapper.Map<Movie, MoviesDto>);

            return Ok(moviesDto);

        }
        //get/api/movie/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MoviesDto>(movie));
        }
        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MoviesDto, Movie>(moviesDto);
            _context.movies.Add(movie);
            _context.SaveChanges();
            moviesDto.Id = movie.Id;

                return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviesDto);
        }
        public IHttpActionResult UpdateMovie (int id, MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();

            _context.movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
