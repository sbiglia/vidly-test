using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> _defaultCustomers = new List<Customer>
        {
            new Customer {Id = 1, Name = "Jhon Smith"},
            new Customer {Id = 2, Name = "Mary Williams"}
        };

        // GET: Customers
        public ActionResult Index()
        {
            return View(_defaultCustomers);
        }
        [Route("Customers/Details/{id}")]
        public ActionResult Detail(int id)
        {
            var found = (from customer in _defaultCustomers where customer.Id == id select customer).FirstOrDefault();

            if (found == null)
            {
                return HttpNotFound();
            }


            return View(found);

        }
    }
}