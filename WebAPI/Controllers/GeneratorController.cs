using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GeneratorController : ControllerBase
    {
        private readonly IGeneratorSvc _generatorSvc;

        public GeneratorController(IGeneratorSvc generatorSvc)
        {
            _generatorSvc = generatorSvc;
        }

        [HttpPost("GenerateImage")]
        [Produces("application/json")]
        public async Task<IActionResult> GenerateImage([FromBody] GenerationDataDTO data)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = await _generatorSvc.AskComfyUI(data, userId);
                return File( result, "image/png");
            }
            catch (ArgumentException)
            {
                return StatusCode(291, new { message = "Insufficient funds 💸" });
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong :(");
            }
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
