using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace video_rental_store.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}