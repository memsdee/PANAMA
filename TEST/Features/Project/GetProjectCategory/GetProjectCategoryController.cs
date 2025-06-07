using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.Project.EditProject;

namespace PANAMA.Features.Project.GetAllProject
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProjectCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetProjectCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProjectCategory")]
        public async Task<IActionResult> GetProjectCategory([FromQuery] GetProjectCategoryQuery request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
