using MediatR;
using PANAMA.Features.Sponsor.DelSponsor;

namespace PANAMA.Features.Sponsor.AddSponsor
{
    public class DelSponsorCommand : IRequest<DelSponsorResponse>
    {
        public int ID { get; set; }
    }
}
