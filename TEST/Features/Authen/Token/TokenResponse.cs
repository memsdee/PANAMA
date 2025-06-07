using MediatR;

namespace PANAMA.Features.Authen.Token
{
    public class TokenResponse
    {
        public int AccountId { get; set; }

        public string Token1 { get; set; } = null!;

        public string RefreshToken { get; set; } = null!;

        public DateTime Expiration { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
