using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Glimpse.AspNet.Tab;
using video_rental_store.Dtos;
using video_rental_store.Models;

namespace video_rental_store.Controllers.Api
{
    public class NewRantalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRantalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            if (newRentalDto.MovieIds.Count == 0)
                return BadRequest("No movie Ids have been given.");

            var customer = _context.Customers.SingleOrDefault(p=>p.Id == newRentalDto.CustomerId);
            if (customer == null)
                return BadRequest("Customer ID is not valid");

            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRentalDto.MovieIds.Count)
                return BadRequest("One or more movies are invalid");


            foreach (var movie in movies)
            {
                if (movie.NumberAvailable < 1)
                    return BadRequest("Movie is not availablle");

                var newRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(newRental);

                movie.NumberAvailable--;
            }
            _context.SaveChanges();


            return Ok();
        }
    }
}
