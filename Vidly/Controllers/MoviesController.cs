using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using System.Data.Entity.Validation; 
using Vidly.ViewModels;

namespace Vidly.Controllers
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
        // GET: Movies
        [Authorize(Roles =RoleName.canManageMovies)]

        public ActionResult New()
        {
            var genres = _context.genres.ToList();
            var viewmodel = new MoviesViewModel
            {
                genres = genres
            };
            return View("NewMovie", viewmodel);
        }
        public ViewResult Index()
        {
            //var movies = _context.movies.Include(m => m.Genre).ToList();


            //if (User.IsInRole(RoleName.canManageMovies))
            if (User.IsInRole("canManageMovie"))

                return View("List");

           return View("ReadOnlyList");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesViewModel
                {

                    genres = _context.genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if(movie.Id==0)
            {
                movie.Date_Add = DateTime.Now;
                _context.movies.Add(movie);
            }
            else
            {
                var movieinDb = _context.movies.Single(m => m.Id == movie.Id);
                movieinDb.Name = movie.Name;
                movieinDb.GenreId = movie.GenreId;
                movieinDb.Stock = movie.Stock;
                movieinDb.Release_Date = movie.Release_Date;

            }

            _context.SaveChanges();
          
            return RedirectToAction("Index", "Movies");

        }

        public ActionResult Edit(int id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MoviesViewModel(movie)
            {
           
                genres = _context.genres.ToList()
            };
            return View("NewMovie", viewModel);

        }
        public ActionResult Details(int id)
        {
            var movie = _context.movies.Include(m =>m.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();


            return View(movie);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        public ActionResult Prueba()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

    }
}