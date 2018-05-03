using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using video_rental_store.Models;

namespace video_rental_store.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}