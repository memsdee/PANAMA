using FluentValidation;

namespace PANAMA.Features.Sponsor.AddSponsor
{
    public class DelSponsorValidator : AbstractValidator<DelSponsorCommand>
    {
        public DelSponsorValidator()
        {
            RuleFor(o => o.ID).NotEmpty().WithMessage("ID sponsor không được để trống");
        }
    }
}
