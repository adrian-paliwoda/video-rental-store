using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using video_rental_store.Models;

namespace video_rental_store.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        [Route("Movies/{pageIndex:int?}/{sortBy?}")]
        [Route("Movies/Index/{pageIndex:int?}/{sortBy?}")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }

            //return View();
            return Content(String.Format("pageIndex: {0}, sortBy: {1}", pageIndex, sortBy));
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


            return View(movie);
        }

        [Route("Movies/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
            //return View();
        }
    }
}