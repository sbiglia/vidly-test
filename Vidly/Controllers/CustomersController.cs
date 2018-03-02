using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
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
            base.Dispose(disposing);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=> c.MembershipType);
            return View(customers);
        }
        [Route("Customers/Details/{id}")]
        public ActionResult Detail(int id)
        {
            var found = (from customer in _context.Customers.Include(c=> c.MembershipType) where customer.Id == id select customer).FirstOrDefault();

            if (found == null)
            {
                return HttpNotFound();
            }


            return View(found);

        }
    }
}