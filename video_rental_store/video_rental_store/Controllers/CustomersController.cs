using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
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
        [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult Index()
        {
            if (MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genres.ToList();
            }

            var ganres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            return View();
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).FirstOrDefault(p => p.Id == id);

            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }

        public ActionResult New()
        {
            var membershipType = _context.MemberShipTypes.ToList();

            var newCustomerViewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MemberShipTypes = membershipType
            };

            return View("CustomerForm",newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0 )
                _context.Customers.Add(customer);
            else
            {
                var customerFromDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerFromDB.Name = customer.Name;
                customerFromDB.BirthDate = customer.BirthDate;
                customerFromDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerFromDB.MemberShipTypeId = customer.MemberShipTypeId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(p => p.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

    }
}