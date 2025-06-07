using MediatR;
using PANAMA.Features.Authen.Token;
using PANAMA.Models;
using Microsoft.EntityFrameworkCore;

namespace PANAMA.Features.Authen.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, TokenResponse>
    {
        private readonly PanamaContext _dbContext;
        private readonly IMediator _mediator;

        public LoginHandler(PanamaContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<TokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(u => u.AdminName == request.AdminName);
            if (account == null || !BCrypt.Net.BCrypt.Verify(request.Pass, account.Pass))
                throw new UnauthorizedAccessException("Tên đăng nhập hoặc mật khẩu không chính xác.");

            var tokenResponse = await _mediator.Send(new TokenCommand { AccountID = account.IdAccount }, cancellationToken);

            return tokenResponse;
        }
    }
}
