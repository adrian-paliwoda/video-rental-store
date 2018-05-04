using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using video_rental_store.Dtos;
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
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MemberShipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto );
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
               BadRequest();

            var customerInDB = _context.Customers.SingleOrDefault(p => p.Id == id);

            if (customerInDB == null)
                NotFound();

            Mapper.Map(customerDto,customerInDB);
            
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(p => p.Id == id);

            if (customerInDB == null)
                NotFound();

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }

    }
}
