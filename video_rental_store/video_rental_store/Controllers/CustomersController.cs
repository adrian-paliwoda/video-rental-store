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

        public ActionResult New()
        {
            var membershipType = _context.MemberShipTypes.ToList();

            var newCustomerViewModel = new CustomerFormViewModel
            {
                MemberShipTypes = membershipType
            };

            return View("CustomerForm",newCustomerViewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
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