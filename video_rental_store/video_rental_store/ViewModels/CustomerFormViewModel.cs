using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using video_rental_store.Models;

namespace video_rental_store.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}