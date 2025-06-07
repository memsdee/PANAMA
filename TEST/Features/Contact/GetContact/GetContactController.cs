using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PANAMA.Features.Contact.GetContact
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetContact")]
        public async Task<IActionResult> GetContact([FromQuery]GetContactQuery request)
        {
            var x = await _mediator.Send(request);
            return Ok(x);
        }
    }
}
