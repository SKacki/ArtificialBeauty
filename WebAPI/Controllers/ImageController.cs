using DAL;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using System.Security.Cryptography.X509Certificates;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageSvc _imageSvc;
        private readonly IOperationSvc _operationSvc;

        public ImageController(IImageSvc imageSvc, IOperationSvc operationSvc)
        {
            _imageSvc = imageSvc;
            _operationSvc = operationSvc;   
        }

        [HttpGet("GetImage")]
        public async Task<IActionResult> GetImage([FromQuery]Guid imageId)
        {
            var img = _imageSvc.GetImage(imageId);
            return File(img, "image/png");
        }

        [HttpGet("GetImageById")]
        public async Task<IActionResult> GetImageById([FromQuery] int imageId)
        {
            var img = _imageSvc.GetImage(imageId);
            return File(img, "image/png");
        }

        [HttpGet("GetImageData")]
        public async Task<IActionResult> GetImageData(int imageId)
        {
            var imgData = _imageSvc.GetImageData(imageId);
            return Ok(imgData);
        }

        [HttpPost("PostReaction")]
        public async Task<IActionResult> PostReaction([FromQuery]int imageId, [FromQuery] int userId,[FromQuery] int type)
        {
            _imageSvc.PostReaction(imageId, userId, type);
            return Ok();
        }

        [HttpPost("TipCreator")]
        public async Task<IActionResult> PostTip([FromQuery] int imageId, [FromQuery] int userId,[FromQuery] int amount)
        {
            _operationSvc.TipImage(imageId, userId, amount);
            return Ok();
        }

        [HttpPost("PostComment")]
        public async Task<IActionResult> PostComment([FromQuery] int imageId, [FromQuery] int userId, [FromQuery] string comment)
        {
            _imageSvc.PostComment(imageId, userId, comment);
            return Ok();
        }

    }
}
