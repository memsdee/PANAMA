using MediatR;
using PANAMA.Models;
using PANAMA.Features.Sponsor.GetSponsor;

namespace PANAMA.Features.Sponsor.AddSponsor
{
    public class AddSponsorHandler : IRequestHandler<AddSponsorCommand, GetSponsorResponse>
    {
        private readonly PanamaContext _dbContext;

        public AddSponsorHandler(PanamaContext db)
        {
            _dbContext = db;
        }

        public async Task<GetSponsorResponse> Handle(AddSponsorCommand request, CancellationToken cancellationToken)
        {
            var sponsor = new Models.Sponsor()
            {
                Name = request.Name,
                LogoPath = request.Logo
            };

            _dbContext.Add(sponsor);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new GetSponsorResponse()
            {     
                ID = sponsor.IdSponsor,
                Name = sponsor.Name,
                FilePath = sponsor.LogoPath,
            };
        }
    }
}
