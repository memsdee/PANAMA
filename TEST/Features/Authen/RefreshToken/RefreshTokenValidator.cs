using FluentValidation;

namespace PANAMA.Features.Authen.RefreshToken
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenValidator()
        {
            RuleFor(o => o.RequestToken).NotEmpty().WithMessage("RefreshToken rỗng");
        }
    }
}
