using DAL;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IOperationSvc _operationSvc;

        public UserController(IOperationSvc operationSvc)
        {
            _operationSvc = operationSvc;   
        }

        [HttpPost("ClaimDailyReward")]
        public async Task<IActionResult> ClaimDailyReward([FromQuery]int userId)
        {
            _operationSvc.ClaimDailyReward(userId);
            return Ok();
        }

    }
}
