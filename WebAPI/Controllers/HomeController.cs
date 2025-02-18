using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //public class HomeForecastController(ILogger<HomeForecastController> logger) : ControllerBase
    public class HomeController() : ControllerBase
    {
        //private readonly ILogger<HomeForecastController> _logger = logger;

        [HttpGet("test")]
        public async Task<string> Get()
        {
            return "Hello World";
        }
    }
}
