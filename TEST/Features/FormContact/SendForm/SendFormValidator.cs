using FluentValidation;

namespace PANAMA.Features.FormContact.SendForm
{
    public class SendFormValidator : AbstractValidator<SendFormCommand>
    {
        public SendFormValidator()
        {
            RuleFor(o => o.UserEmail)
                .NotEmpty().WithMessage("Email không được trống")
                .EmailAddress().WithMessage("Không đúng định dạng email");

            RuleFor(o => o.UserName)
                .NotEmpty().WithMessage("Tên không được trống");

            RuleFor(o => o.AreaOfInterest)
                .NotEmpty().WithMessage("AreaOfInterest không được trống");

            RuleFor(o => o.Content)
                .NotEmpty().WithMessage("Nội dung không được trống");
        }
    }
}
