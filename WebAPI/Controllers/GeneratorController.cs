using DAL;
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
        private readonly IGeneratorSvc _generatorSvc;

        public GeneratorController(IGeneratorSvc generatorSvc)
        {
            _generatorSvc = generatorSvc;
        }

        [HttpPost("GenerateImage")]
        [Produces("application/json")]
        public async Task<IActionResult> GenerateImage([FromBody] GenerationDataDTO metadata)
        {
            var result = await _generatorSvc.AskComfyUI(metadata);
            return result == null ? BadRequest("Something went wrong :(") :  File(result, "image/png");
        }

        [HttpGet("HealthCheck")]
        [Produces("application/json")]
        public async Task<IActionResult> HealthCheck()
        {
            var result = await _generatorSvc.HealthCheck() ?? -1;   
            return Ok(new MyClass() { Message = "OK", Code = result });
        }

        [HttpPost("GetWorkflow")]
        [Produces("application/json")]
        public async Task<IActionResult> GetWorkflow([FromBody] GenerationDataDTO metadata)
        {
            var result = _generatorSvc.GetWorkflow(metadata);
            return Ok(result);
        }
    }

    public class MyClass
    {
        public string Message {  get; set; }
        public int Code { get; set; }
        
    }
}
