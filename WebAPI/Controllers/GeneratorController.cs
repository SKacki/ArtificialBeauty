﻿using Logic.Interfaces;
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
            var workflow = _generatorSvc.GetWorkflow(metadata);
            var result = await _generatorSvc.AskComfyUI(workflow);
            return result == null ? BadRequest("Something went wrong :(") :  File(result, "image/png");
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
