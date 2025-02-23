using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    //public class HomeForecastController(ILogger<HomeForecastController> logger) : ControllerBase
    public class GeneratorController : ControllerBase
    {
        //private readonly ILogger<HomeForecastController> _logger = logger;
        private readonly IModelSvc _modelSvc;

        public GeneratorController(IModelSvc modelSvc)
        { 
            _modelSvc = modelSvc;
        
        }

        [HttpGet("test")]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            //var result = _modelSvc.GetByName("BBC");

            return Ok();
        }

        [HttpGet("GetImage/{imageName}")]
        public async Task<IActionResult> GetImage(string imageName)
        {
            var imagePath = Path.Combine("C:\\NFOSIGW\\ArtificialBeauty\\Images", "9f2d3a5b-1c4e-4d8f-8a68-3e2b1d6f5c7e.png");

            if (!System.IO.File.Exists(imagePath))
            {
                return BadRequest("Image not found");
            }

            var imageBytes = System.IO.File.ReadAllBytes(imagePath);

            return File(imageBytes, "image/png");
        }

        [HttpPost("GenerateImage")]
        [Produces("application/json")]
        public async Task<IActionResult> GenerateImage([FromBody] MetadataDTO metadata)
        {
            return Ok("test");
        }

    }
}
