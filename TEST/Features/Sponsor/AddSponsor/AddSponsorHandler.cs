using MediatR;
using PANAMA.Models;
using PANAMA.Common.Service;

namespace PANAMA.Features.Sponsor.AddSponsor
{
    public class AddSponsorHandler : IRequestHandler<AddSponsorCommand, AddSponsorResponse>
    {
        private readonly PanamaContext _dbContext;

        public AddSponsorHandler(PanamaContext db)
        {
            _dbContext = db;
        }

        public async Task<AddSponsorResponse> Handle(AddSponsorCommand request, CancellationToken cancellationToken)
        {
            var file = await SaveImg.SaveFile(request.Logo,request.Name,cancellationToken);

            var sponsor = new Models.Sponsor()
            {
                Name = request.Name,
                LogoPath = file
            };

            _dbContext.Add(sponsor);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new AddSponsorResponse()
            {
                Success = true,
                ID = sponsor.IdSponsor,
            };
        }
    }
}
