using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.Project.AddProject;

namespace PANAMA.Features.Project.EditProject
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EditProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("EditProject")]
        public async Task<IActionResult> EditProject([FromForm] EditProjectCommand request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
