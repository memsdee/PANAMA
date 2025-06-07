using FluentValidation;
using PANAMA.Common.Validator;
using PANAMA.Share.Validator;

namespace PANAMA.Features.Sponsor.AddSponsor
{
    public class AddSponsorValidator : AbstractValidator<AddSponsorCommand>
    {
        public AddSponsorValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("Tên sponsor không được để trống");
            RuleFor(o => o.Logo).NotEmpty().WithMessage("Logo không được để trống")
                .Must(o => ImgValidator.ValidateImg(o)).WithMessage("Định dạng file không được hỗ trợ");
        }
    }
}
