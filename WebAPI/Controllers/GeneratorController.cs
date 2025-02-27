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
        private readonly IGeneratorSvc _generatorSvc;
        private readonly IImageSvc _imageSvc;

        public GeneratorController(IModelSvc modelSvc, IGeneratorSvc generatorSvc, IImageSvc imageSvc)
        {
            _modelSvc = modelSvc;
            _generatorSvc = generatorSvc;
            _imageSvc = imageSvc;
        }

        [HttpGet("test")]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            //var result = _modelSvc.GetByName("BBC");

            return Ok();
        }

        [HttpGet("GetImage")]
        public async Task<IActionResult> GetImage(int imageId)
        {
            var img = _generatorSvc.GetImage(imageId);
            return File(img, "image/png");
        }

        [HttpGet("GetImageData")]
        public async Task<IActionResult> GetImageData(int imageId)
        {
            var imgData = _imageSvc.GetImageData(imageId);
            return Ok(imgData);
        }

        [HttpPost("GenerateImage")]
        [Produces("application/json")]
        public async Task<IActionResult> GenerateImage([FromBody] MetadataDTO metadata)
        {
            return Ok("test");
        }

        [HttpGet("HealthCheck")]
        [Produces("application/json")]
        public async Task<IActionResult> HealthCheck([FromQuery] int code)
        {
            var result = new MyClass() { Res = "OK", Code = code };
            return Ok(result);
        }
    }

    public class MyClass
    {
        public string Res {  get; set; }
        public int Code { get; set; }
        
    }
}
