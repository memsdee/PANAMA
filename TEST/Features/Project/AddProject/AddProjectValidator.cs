using FluentValidation;
using PANAMA.Common.Validator;
using PANAMA.Share.Validator;

namespace PANAMA.Features.Project.AddProject
{
    public class AddProjectValidator : AbstractValidator<AddProjectCommand>
    {
        public AddProjectValidator()
        {
            RuleFor(o => o.Category)
                .NotEmpty().WithMessage("Category không được trống");

            RuleFor(o => o.Title)
                .NotEmpty().WithMessage("Title không được trống");

            RuleFor(o => o.TimeProject)
                .NotEmpty().WithMessage("TimeProject không được trống");

            RuleFor(o => o.DescProject)
                .NotEmpty().WithMessage("Description không được trống");


            RuleFor(o => o.Thumbnail)
                .NotNull().WithMessage("Thumbnail không được trống")
                .Must(o => ImgValidator.ValidateImg(o))
                .WithMessage("Định dạng file ảnh Thumbnail không được hỗ trợ");

            RuleFor(o => o.Media)
                .NotNull().WithMessage("Media không được trống")
                .Must(o => MediaValidator.ValidateMedia(o))
                .WithMessage("Định dạng file trong media không được hỗ trợ hoặc độ lượng video quá lớn");
        }
    }
}
