using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PANAMA.Features.Contact.AddContact
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddContactController(IMediator x)
        {
            _mediator = x;
        }

        [HttpPost("AddContact")]
        public async Task<IActionResult> AddContact([FromBody] AddContactCommand request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
