using FluentValidation;

namespace PANAMA.Features.Authen.Login
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(o=>o.AdminName).NotEmpty().WithMessage("Tên đăng nhập không được để trống");
            RuleFor(o => o.Pass).NotEmpty().WithMessage("Mật khẩu không được để trống");
        }
    }
}
