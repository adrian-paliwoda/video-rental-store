﻿using System;
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
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customerQuery = _context.Customers
                .Include(c => c.MemberShipType);

            if (!String.IsNullOrWhiteSpace(query))
                customerQuery = customerQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customerQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(p => p.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
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
        [Authorize(Roles = RoleName.CanManageMovies)]
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
        [System.Web.Mvc.Authorize(Roles = RoleName.CanManageMovies)]
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
