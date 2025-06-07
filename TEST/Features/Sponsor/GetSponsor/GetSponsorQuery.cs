using MediatR;
using PANAMA.Models;

namespace PANAMA.Features.Sponsor.GetSponsor
{
    public class GetSponsorQuery :IRequest<List<GetSponsorResponse>>
    {
    }
}
