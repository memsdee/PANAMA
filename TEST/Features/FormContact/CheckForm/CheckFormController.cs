using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PANAMA.Features.FormContact.GetAllForm;

namespace PANAMA.Features.FormContact.CheckForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckFormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckFormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("CheckForm")]
        public async Task<IActionResult> SendForm([FromBody] CheckFormCommand request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
