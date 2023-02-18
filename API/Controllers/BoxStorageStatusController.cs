using API.Context;
using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoxStorageStatusController : BaseController
    {
        public BoxStorageStatusController(FrontDeskDbContext dbContext) : base(dbContext)
        {
        }

        [HttpPost]
        public IActionResult RecordBoxStorageStatus(BoxStorageStatus boxStorageStatus)
        {
            try
            {
                var storageArea = _dbContext.StorageAreas.FirstOrDefault(s => s.Size == int.Parse(boxStorageStatus.BoxSize));

                // if there are available storage area for the requested size, accept it
                // else tell user there is no available storage area
                if (storageArea != null && storageArea.Available > 0)
                {                    
                    boxStorageStatus.StorageAreaId = storageArea.Id;
                    storageArea.Available--;                    

                    _dbContext.BoxStorageStatuses.Add(boxStorageStatus);
                    _dbContext.SaveChanges();

                    return Ok(boxStorageStatus);
                }
                else
                {
                    return BadRequest("Not enough space");
                }

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
