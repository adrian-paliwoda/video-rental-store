using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using video_rental_store.Models;
using video_rental_store.ViewModels;

namespace video_rental_store.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType);


            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).FirstOrDefault(p => p.Id == id);

            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }

        public ActionResult  New()
        {
            var membershipType = _context.MemberShipTypes.ToList();

            var newCustomerViewModel = new NewCustomerViewModel
            {
                MemberShipTypes = membershipType
            };

            return View(newCustomerViewModel);
        }

    }
}