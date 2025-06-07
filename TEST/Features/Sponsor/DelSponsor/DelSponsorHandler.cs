using MediatR;
using Microsoft.EntityFrameworkCore;
using PANAMA.Features.Sponsor.DelSponsor;
using PANAMA.Models;

namespace PANAMA.Features.Sponsor.AddSponsor
{
    public class DelSponsorHandler : IRequestHandler<DelSponsorCommand, DelSponsorResponse>
    {
        private readonly PanamaContext _dbContext;

        public DelSponsorHandler(PanamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DelSponsorResponse> Handle(DelSponsorCommand request, CancellationToken cancellationToken)
        {
            var sponsor = await _dbContext.Sponsors.FirstOrDefaultAsync(o=>o.IdSponsor==request.ID);

            if (sponsor == null)
                throw new KeyNotFoundException("Không thấy dữ liệu hợp lệ");

            File.Delete(sponsor.LogoPath);

            _dbContext.Remove(sponsor);       
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new DelSponsorResponse()
            {
                Success = true
            };
        }
    }
}
