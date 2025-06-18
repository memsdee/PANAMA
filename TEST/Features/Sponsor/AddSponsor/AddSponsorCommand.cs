using MediatR;
using PANAMA.Features.Sponsor.GetSponsor;

namespace PANAMA.Features.Sponsor.AddSponsor
{
    public class AddSponsorCommand : IRequest<GetSponsorResponse>
    {
        public string Name { get; set; } = null!;
        public string Logo { get; set; } = null!;
    }
}
