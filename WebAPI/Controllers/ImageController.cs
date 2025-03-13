using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace WebAPI.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet("GetImage")]
        public async Task<IActionResult> GetImage([FromQuery]Guid imageId)
        {
            var img = _imageSvc.GetImage(imageId);
            return File(img, "image/png");
        }
        
        [AllowAnonymous]
        [HttpGet("GetImageById")]
        public async Task<IActionResult> GetImageById([FromQuery] int imageId)
        {
            var img = _imageSvc.GetImage(imageId);
            return File(img, "image/png");
        }

        [HttpGet("GetImageData")]
        public async Task<IActionResult> GetImageData([FromQuery] int imageId)
        {
            var imgData = _imageSvc.GetImageData(imageId);
            return Ok(imgData);
        }

        [HttpGet("GetImageMetaData")]
        public async Task<IActionResult> GetImageMetaData([FromQuery]int imageId)
        {
            var imgData = _imageSvc.GetImageMetadata(imageId);
            return Ok(imgData);
        }

        [HttpPost("PostReaction")]
        public async Task<IActionResult> PostReaction([FromBody] ReactionDTO reaction)
        {
            try
            {
                var result = _imageSvc.PostReaction(reaction);

                switch (result)
                {
                    case 0:
                        return Ok(new { message = "OK" });
                    case -1:
                        return StatusCode(290, new { message = "Can't vote for your image ✋🏻" });
                    case -2:
                        return StatusCode(291, new { message = "Already voted for that image" });
                    default:
                        return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("TipCreator")]
        public async Task<IActionResult> PostTip([FromBody] TipDTO tip)
        {
            try
            {
                var result = _operationSvc.TipImage(tip);

                switch (result) 
                {
                    case 0:
                        return Ok(new{ message = "OK" });
                    case -1:
                        return StatusCode(291, new { message = "You can't tip yourself 💸" });
                    case -2:
                        return StatusCode(290, new { message = "Insufficient funds 💸" });
                    default:
                        return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostComment")]
        public async Task<IActionResult> PostComment([FromBody] CommentDTO comment)
        {
            try
            {
                _imageSvc.PostComment(comment);
                return Ok(new { message = "OK" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("PublishImage")]
        public async Task<IActionResult> PublishImage([FromBody] ImageDTO image)
        {
            try
            {
                var result = _imageSvc.PublishImage(image);
                return result == -1 ? StatusCode(291, new { message = "Ok, but no award 💸" }) : Ok(new { message = "OK" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetImageComments")]
        public async Task<IActionResult> GetComments([FromQuery] int imageId)
        {
            var imgData = _imageSvc.GetComments(imageId);
            return Ok(imgData);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> RemoveImage([FromQuery] string imageId)
        {
            try
            {
                _imageSvc.RemoveImage(Guid.Parse(imageId));
                return Ok(new {message = "OK"});
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex);
            }
        }

        

    }
}
