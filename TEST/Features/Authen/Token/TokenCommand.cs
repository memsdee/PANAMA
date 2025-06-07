using MediatR;

namespace PANAMA.Features.Authen.Token
{
    public class TokenCommand : IRequest<TokenResponse>
    {
        public int AccountID { get; set; } 
    }
}
