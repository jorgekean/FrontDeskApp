using API.Context;
using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseController
    {
        public CustomerController(FrontDeskDbContext dbContext) : base(dbContext)
        {
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();

                return Ok(customer);
            }
            catch (Exception ex)
            {
                // error logging here
                throw ex;
            }

            return BadRequest();
        }
    }
}
