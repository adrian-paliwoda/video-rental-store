using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using video_rental_store.Models;

namespace video_rental_store.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}