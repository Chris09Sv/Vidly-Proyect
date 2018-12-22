using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.App_Start;
using System.Data.Entity;
using AutoMapper;
using Vidly.Dtos;
namespace Vidly.Controllers.API
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        //get/api/customer
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.customers.Include(c=> c.MembershipType)
                .ToList().Select(Mapper.Map<Customer, CustomersDtos>);


            return Ok(customerDtos);
        }

        //get/api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return NotFound();

            return Ok( Mapper.Map<Customer,CustomersDtos>(customer));
        }

        //po0st/aspi/customers
        [HttpPost]
        public  IHttpActionResult CreateCustomer(CustomersDtos customerDto){
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomersDtos, Customer>(customerDto);
            _context.customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;


            return Created(new Uri(Request.RequestUri+ "/"+customer.Id),customerDto);

        }
        //put/api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomersDtos customersDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();

                    var customerInDb = _context.customers.SingleOrDefault(x => x.Id == id);

            if (customerInDb == null)
                return NotFound();
                    Mapper.Map(customersDtos, customerInDb);
           
            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id) { 

            var customerInDb = _context.customers.SingleOrDefault(x => x.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
