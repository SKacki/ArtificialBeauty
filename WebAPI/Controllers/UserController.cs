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
    public class UserController : ControllerBase
    {
        private readonly IOperationSvc _operationSvc;
        private readonly IUserSvc _userSvc;

        public UserController(IOperationSvc operationSvc, IUserSvc userSvc)
        {
            _operationSvc = operationSvc;
            _userSvc = userSvc;
        }

        [HttpPost("ClaimDailyReward")]
        public async Task<IActionResult> ClaimDailyReward([FromQuery] int userId)
        {
            try
            {
                var status = _operationSvc.ClaimDailyReward(userId);
                return status == 1 ? Ok(new { message = "OK" }) : StatusCode(291, new { message = "Already claimed today 💰" }); ;
            }
            catch (Exception ex) 
            { 
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetOperationHistory")]
        public async Task<IActionResult> GetOperationHistory([FromQuery] int userId)
        {
            var result = _operationSvc.GetUserOperations(userId);
            return Ok(result);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser([FromQuery] int userId)
        {
            var result = _userSvc.GetUserById(userId);
            return Ok(result);
        }

        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUser([FromQuery] string email)
        {
            var result = _userSvc.GetUserByEmail(email);
            return Ok(result);
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO user)
        {
            await _userSvc.UpdateUser(user);
            return Ok(new { message = "OK" });
        }

        [HttpPost("FollowUser")]
        public async Task<IActionResult> FollowUser([FromBody] FollowDTO follow)
        {
            var userUid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = _userSvc.GetUserByUid(Guid.Parse(userUid)).Id;
            if (userId != follow.FollowerId)
                return Unauthorized("You don't have permission for this operation");
            
            try
            {
                await _userSvc.FollowUser(follow);
                return Ok(new { message = "OK" });
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("upload-profile")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile profilePic)
        {
            byte[] bytes = null;
            if (profilePic == null || profilePic.Length == 0)
                return BadRequest("No file uploaded");

            var userId = _userSvc.GetUserByUid(Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value)).Id;
            using (var memoryStream = new MemoryStream())
            {
                await profilePic.CopyToAsync(memoryStream);
                bytes= memoryStream.ToArray();
            }

            _userSvc.UpdateProfilePic(bytes, userId);
            return Ok();
        }

        [HttpGet("Test")]
        public async Task<IActionResult> TestUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var username = User.Identity?.Name;

            return Ok(new { userId, email, username });
        }

    }
}
