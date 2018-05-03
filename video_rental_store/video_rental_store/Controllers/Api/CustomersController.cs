using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using video_rental_store.Models;

namespace video_rental_store.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(p => p.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customers.SingleOrDefault(p => p.Id == id);

            if ( customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDB.Name = customer.Name;
            customerInDB.BirthDate = customer.BirthDate;
            customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDB.MemberShipTypeId= customer.MemberShipTypeId;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(p => p.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }

    }
}
