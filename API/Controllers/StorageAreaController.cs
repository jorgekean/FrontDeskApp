using API.Context;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageAreaController : Controller
    {
        private FrontDeskDbContext _dbContext;

        public StorageAreaController()
        {
            _dbContext = new FrontDeskDbContext();
        }

        [HttpGet]
        public IActionResult CheckStorageAreaAvailability(int boxSize)
        {
            var storageAreas = _dbContext.StorageAreas.Where(s => s.Size >= boxSize).ToList();

            return Ok(storageAreas);
        }
    }
}
