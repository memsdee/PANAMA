using MediatR;
using Microsoft.EntityFrameworkCore;
using PANAMA.Models;

namespace PANAMA.Features.Sponsor.GetSponsor
{
    public class GetSponsorHandler :IRequestHandler<GetSponsorQuery, List<GetSponsorResponse>>
    {
        private readonly PanamaContext _dbContext;

        public GetSponsorHandler(PanamaContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<List<GetSponsorResponse>> Handle(GetSponsorQuery request, CancellationToken cancellationToken)
        {
            var sponsor = await _dbContext.Sponsors.Select(o => new GetSponsorResponse
            {
                ID = o.IdSponsor,
                Name = o.Name,
                FilePath = o.LogoPath,
            }).ToListAsync(cancellationToken);

            if (!sponsor.Any())
                throw new KeyNotFoundException("Không có sponsor nào");

            return sponsor;
        }
    }
}
