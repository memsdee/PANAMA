using MediatR;
using Microsoft.EntityFrameworkCore;
using PANAMA.Features.Authen.Token;
using PANAMA.Models;

namespace PANAMA.Features.Authen.RefreshToken
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, TokenResponse>
    {
        private readonly PanamaContext _dbContext;
        private readonly IMediator _mediator;

        public RefreshTokenHandler(PanamaContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<TokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var requestToken = await _dbContext.Tokens.FirstOrDefaultAsync(a => a.RefreshToken == request.RequestToken);

            if (requestToken == null )
                throw new KeyNotFoundException("RequestToken không hợp lệ ");

            var tokenCommand = new TokenCommand { AccountID = requestToken.AccountId };
            var tokenResponse = await _mediator.Send(tokenCommand, cancellationToken);
            _dbContext.Tokens.Remove(requestToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return tokenResponse;
        }
    }
}
