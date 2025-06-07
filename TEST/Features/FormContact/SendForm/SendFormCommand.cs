using MediatR;

namespace PANAMA.Features.FormContact.SendForm
{
        public class SendFormCommand : IRequest<SendFormResponse>
    {
        public string UserEmail { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string AreaOfInterest { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreateAt { get; set; }
    }
}
