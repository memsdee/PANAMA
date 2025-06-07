using MediatR;
using PANAMA.Features.Authen.Token;

namespace PANAMA.Features.Authen.RefreshToken
{
    public class RefreshTokenCommand : IRequest<TokenResponse>
    {
        public string RequestToken { get; set; } = null!;
    }
}
