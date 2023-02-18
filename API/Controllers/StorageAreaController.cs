using API.Context;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageAreaController : BaseController
    {
        public StorageAreaController(FrontDeskDbContext dbContext) : base(dbContext)
        {
        }

        [HttpGet]
        public IActionResult CheckStorageAreaAvailability(int boxSize)
        {
            try
            {
                var storageAreas = _dbContext.StorageAreas.Where(s => s.Size >= boxSize).ToList();
                return Ok(storageAreas);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
            return BadRequest();
           
        }
    }
}
