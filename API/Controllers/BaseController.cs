using API.Context;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : Controller
    {
        protected FrontDeskDbContext _dbContext;

        public BaseController(FrontDeskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
