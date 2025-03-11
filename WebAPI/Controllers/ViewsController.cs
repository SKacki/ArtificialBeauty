using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("GetModelView")]
        [Produces("application/json")]
        public async Task<IActionResult> ModelView([FromQuery] int modelId)
        {
            var result = _viewSvc.GetModelView(modelId);
            return Ok(result);
        }
        [HttpGet("GetOperationsView")]
        [Produces("application/json")]
        public async Task<IActionResult> OperationsView([FromQuery] int userId)
        {
            var result = _viewSvc.GetOperationView(userId);
            return Ok(result);
        }
        
        [HttpGet("GetGeneratorView")]
        [Produces("application/json")]
        public async Task<IActionResult> GeneratorView([FromQuery] int imageId)
        {
            var result = _viewSvc.GetGeneratorView(imageId);
            return Ok(result);
        }

        [HttpGet("GetfeatureImages")]
        [Produces("application/json")]
        public async Task<IActionResult> FeatureImagesView()
        {
            var result = _viewSvc.GetFeatureImagesView();
            return Ok(result);
        }

        [HttpGet("GetImageView")]
        [Produces("application/json")]
        public async Task<IActionResult> GetImageView([FromQuery] string? searchTerm)
        {
            var result = _viewSvc.GetImagesView(searchTerm);
            return Ok(result);
        }

        [HttpGet("GetfeatureModels")]
        [Produces("application/json")]
        public async Task<IActionResult> FeatureModelsView()
        {
            var result = _viewSvc.GetFeatureModelsView();
            return Ok(result);
        }

        [HttpGet("GetAllModels")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllModels()
        {
            var result = _viewSvc.GetAllModelsView();
            return Ok(result);
        }
    }
}
