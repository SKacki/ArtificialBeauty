using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ModelController : ControllerBase
    {
        private readonly IModelSvc _modelSvc;

        public ModelController(IModelSvc modelSvc)
        { 
            _modelSvc = modelSvc;
        
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            var result = _modelSvc.GetAll();

            return Ok(result);
        }

        [HttpGet("Search")]
        [Produces("application/json")]
        public async Task<IActionResult> Search([FromQuery] string searchTerm)
        {
            var result = _modelSvc.SearchByName(searchTerm);

            return Ok(result);
        }

        [HttpGet("GetCheckpoints")]
        [Produces("application/json")]
        public async Task<IActionResult> GetCheckpoints()
        {
            var result = _modelSvc.GetCheckpoints();

            return Ok(result);
        }
        
        [HttpGet("GetAdditional")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAdditionalResources()
        {
            var result = _modelSvc.GetAdditionalResources();

            return Ok(result);
        }

    }
}
