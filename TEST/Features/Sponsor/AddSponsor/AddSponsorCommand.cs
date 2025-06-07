using MediatR;

namespace PANAMA.Features.Sponsor.AddSponsor
{
    public class AddSponsorCommand : IRequest<AddSponsorResponse>
    {
        public string Name { get; set; } = null!;
        public IFormFile Logo { get; set; } = null!;
    }
}
