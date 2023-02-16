using API.Context;
using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private FrontDeskDbContext _dbContext;

        public CustomerController()
        {
            _dbContext = new FrontDeskDbContext();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return Ok(customer);
        }
    }
}
