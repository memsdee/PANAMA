using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PANAMA.Features.Contact.EditContact
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EditContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("EditContact")]
        public async Task<IActionResult> EditContact([FromBody] EditContactCommand request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
