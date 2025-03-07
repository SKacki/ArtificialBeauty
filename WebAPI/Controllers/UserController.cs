using DAL;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using System.Net;

namespace WebAPI.Controllers
{

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
                return status == 1 ? Ok() : StatusCode(801, new { message = "Already claimed today 💰" }); ;
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
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

        [HttpPost("PostUser")]
        public async Task<IActionResult> PostUser([FromBody] NewUserDTO user)
        {
             var usrId = await _userSvc.PostUser(user);

            return Ok(usrId);
        }

    }
}
