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
            var movies = _context.Movies.Include(m => m.Genre);

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

        [Route("Movies/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
            //return View();
        }
    }
}