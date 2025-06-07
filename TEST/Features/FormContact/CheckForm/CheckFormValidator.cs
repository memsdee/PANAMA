using FluentValidation;

namespace PANAMA.Features.FormContact.CheckForm
{
    public class CheckFormValidator : AbstractValidator<CheckFormCommand>
    {
        public CheckFormValidator()
        {
            RuleFor(o => o.Id).NotEmpty().WithMessage("ID không được để trống");
        }
    }
}
