using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.FormContact.GetAllForm;
using FluentValidation;
namespace PANAMA.Features.Project.AddProject
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddProjectController(IMediator mediator, IWebHostEnvironment evn)
        {
            _mediator = mediator;
        }

        [HttpPost("AddProject")]
        public async Task<IActionResult> AddProject([FromForm] AddProjectCommand request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
