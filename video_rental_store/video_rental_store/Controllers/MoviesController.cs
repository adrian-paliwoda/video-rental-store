using System;
using System.Collections.Generic;
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
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = GetMovies().FirstOrDefault(p => p.Id == id);

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


        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 0, Name = "Shrek"},
                new Movie {Id = 1, Name = "Memento"}
            };
        }
    }
}