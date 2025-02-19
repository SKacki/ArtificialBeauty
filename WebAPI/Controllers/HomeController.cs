using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    //public class HomeForecastController(ILogger<HomeForecastController> logger) : ControllerBase
    public class HomeController : ControllerBase
    {
        //private readonly ILogger<HomeForecastController> _logger = logger;
        private readonly IModelSvc _modelSvc;

        public HomeController(IModelSvc modelSvc)
        { 
            _modelSvc = modelSvc;
        
        }

        [HttpGet("test")]
        public async Task<List<ModelDTO>> Get()
        {
            return _modelSvc.GetAllModels().ToList();
        }
    }
}
