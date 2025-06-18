using FluentValidation;

namespace PANAMA.Features.Sponsor.AddSponsor
{
    public class AddSponsorValidator : AbstractValidator<AddSponsorCommand>
    {
        public AddSponsorValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("Tên sponsor không được để trống");
            RuleFor(o => o.Logo).NotEmpty().WithMessage("Logo không được để trống");

        }
    }
}
