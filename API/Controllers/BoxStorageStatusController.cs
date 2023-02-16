using API.Context;
using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoxStorageStatusController : Controller
    {
        private FrontDeskDbContext _dbContext;

        public BoxStorageStatusController()
        {
            _dbContext = new FrontDeskDbContext();
        }

        [HttpPost]
        public IActionResult RecordBoxStorageStatus(BoxStorageStatus boxStorageStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var storageArea = _dbContext.StorageAreas.FirstOrDefault(s => s.Id == boxStorageStatus.StorageAreaId);

            if (storageArea != null && storageArea.Available > 0)
            {
                storageArea.Available--;
                _dbContext.SaveChanges();

                _dbContext.BoxStorageStatuses.Add(boxStorageStatus);
                _dbContext.SaveChanges();

                return Ok(boxStorageStatus);
            }
            else
            {
                return BadRequest("Not enough space");
            }
        }
    }

}
