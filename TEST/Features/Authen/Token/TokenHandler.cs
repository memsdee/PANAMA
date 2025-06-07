using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PANAMA.Models;
using PANAMA.Share.Infrastructure;

namespace PANAMA.Features.Authen.Token
{
    public class TokenHandler : IRequestHandler<TokenCommand, TokenResponse>
    {
        private readonly JwtSettings _jwtSettings;
        private readonly PanamaContext _dbContext;

        public TokenHandler(JwtSettings jwtSettings, PanamaContext dbContext)
        {
            _jwtSettings = jwtSettings;
            _dbContext = dbContext;
        }

        public async Task<TokenResponse> Handle(TokenCommand request, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, request.AccountID.ToString()),
            new Claim(ClaimTypes.Role, "admin")
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.Now,
                Issuer = _jwtSettings.Issuer,   
                Audience = _jwtSettings.Audience,
                Expires = DateTime.Now.AddDays(_jwtSettings.Expiry),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            var refreshToken = Guid.NewGuid().ToString();

            var tokenEntity = new Models.Token
            {
                AccountId = request.AccountID,
                Token1 = jwtToken,
                RefreshToken = refreshToken,
                Expiration = tokenDescriptor.Expires.Value,
                CreatedAt = DateTime.Now,
            };

            _dbContext.Tokens.Add(tokenEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new TokenResponse
            {
                AccountId = request.AccountID,
                Token1 = jwtToken,
                RefreshToken = refreshToken,
                Expiration = tokenDescriptor.Expires.Value,
                CreatedAt = DateTime.Now
            };
        }
    }
}
