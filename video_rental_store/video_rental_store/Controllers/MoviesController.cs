using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using video_rental_store.Models;
using video_rental_store.ViewModel;
using video_rental_store.ViewModels;

namespace video_rental_store.Controllers
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
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }



        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).FirstOrDefault(p => p.Id == id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }

        [Route("Movies/released/{year:regex(\\d{4}):int?}/{month:range(1,12):int?}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            if (!year.HasValue)
            {
                year = DateTime.Now.Year;
            }

            if (!month.HasValue)
            {
                month = DateTime.Now.Month;
            }

            return Content(year + " " + month);
            //return View();
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);

        }

        [Route("Movies/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDB.Name = movie.Name;
                movieInDB.AddedDate = movie.AddedDate;
                movieInDB.Genre = movie.Genre;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.NumberInStock = movie.NumberInStock;
            }

              _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}