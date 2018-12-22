using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //db context to access the database
        private ApplicationDbContext _context;
        // inicializamos en el constructor, este es un
        public  CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers

        public ActionResult New()
        {
            var membershipTypes = _context.membershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel

            {
                Customer = new Customer(),
                membershipTypes = membershipTypes
            };
            return View("CustomerForm", viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    membershipTypes = _context.membershipTypes.ToList()
                };
               
            
                return View("CustomerForm", viewmodel);

            }
        

            if (customer.Id == 0)
                _context.customers.Add(customer);
            else
            {
                var customerInDb = _context.customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Index()
        {
            //var customers = _context.customers.Include(c => c.MembershipType).ToList();
            ////thus is a db set that define in a db context to get everything in the db
            //return View(custom ers);
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
      
        public ActionResult Edit(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                membershipTypes = _context.membershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);

        }
    }
}



