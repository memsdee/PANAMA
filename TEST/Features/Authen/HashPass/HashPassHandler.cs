using MediatR;
using Microsoft.EntityFrameworkCore;
using PANAMA.Models;
using BCrypt.Net;

namespace PANAMA.Features.Authen.HashPass
{
    public class HashPassHandler : IRequestHandler<HashPassCommand, bool>
    {
        private readonly PanamaContext _dbContext;

        public HashPassHandler(PanamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(HashPassCommand request, CancellationToken cancellationToken)
        {
            var account = await _dbContext.Accounts.ToListAsync(cancellationToken);

            foreach (var o in account)
            {
                if (!string.IsNullOrEmpty(o.Pass) && !o.Pass.StartsWith("$2a$"))
                    o.Pass = BCrypt.Net.BCrypt.HashPassword(o.Pass);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

