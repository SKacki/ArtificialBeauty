using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ViewController : ControllerBase
    {
        private readonly IViewSvc _viewSvc;

        public ViewController(IViewSvc viewSvc)
        {
            _viewSvc = viewSvc;
        
        }

        [HttpGet("GetUserView")]
        [Produces("application/json")]
        public async Task<IActionResult> UserView([FromQuery] int userId)
        {

            var result = _viewSvc.GetUserView(userId);

            return Ok(result);
        }
    }
}
