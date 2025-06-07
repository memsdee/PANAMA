using MediatR;
using PANAMA.Features.Authen.Token;

namespace PANAMA.Features.Authen.Login
{
    public class LoginCommand : IRequest<TokenResponse>
    {
        public string AdminName { get; set; } = null!;
        public string Pass { get; set; } = null!;
    }
}
