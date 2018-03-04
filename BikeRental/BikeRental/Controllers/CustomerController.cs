using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BikeRental.DatabaseContext;
using static BikeRental.Model.Model;

namespace BikeRental.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("Customers")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                using (Context context = new Context())
                {
                    return Ok(context.Customers.ToList());
                }
            }
            catch (Exception)
            {
                return BadRequest("Datenbankfehler...");
            }
        }

        [HttpGet]
        [Route("Customers/{name}")]
        public IActionResult GetCustomerByName(string name)
        {
            try
            {
                using (Context context = new Context())
                {
                    return Ok(context.Customers.Where(x => x.LastName.Contains(name)).ToList());
                }
            }
            catch (Exception)
            {
                return BadRequest("Datenbankfehler...");
            }
        }

        [HttpPost]
        [Route("Customers")]
        public IActionResult CreateNewCustomer(Customer customer)
        {
            
            try
            {
                using (Context context = new Context())
                {
                    context.Add(customer);
                    context.SaveChanges();
                    return Ok("Customer wurde erstellt...");
                }
            }
            catch (Exception e)
            {
                //return BadRequest("Datenbankfehler...");
                return BadRequest(e.StackTrace);
            }

            //return Ok(customer);
        }

        [HttpPut]
        [Route("Customers")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                using (Context context = new Context())
                {
                    Customer data = context.Customers.SingleOrDefault(x => x.CustomerID == customer.CustomerID);
                    data = customer;
                    context.SaveChanges();

                    return Ok("Customer wurde aktualisiert...");
                }
            }
            catch (Exception)
            {
                return BadRequest("Datenbankfehler...");
            }
        }

        [HttpDelete]
        [Route("Customers/{CustomerID}")]
        public IActionResult DeleteCustomer(int CustomerID)
        {
            try
            {
                using (Context context = new Context())
                {
                    context.Customers.Remove(context.Customers.Where(x => x.CustomerID == CustomerID).SingleOrDefault());
                    context.SaveChanges();

                    return Ok("Customer wurde gelöscht...");
                }
            }
            catch (Exception)
            {
                return BadRequest("Datenbankfehler...");
            }
        }
    }
}