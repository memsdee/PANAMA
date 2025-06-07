using FluentValidation;
using PANAMA.Common.Validator;
using PANAMA.Share.Validator;

namespace PANAMA.Features.Project.EditProject
{
    public class EditProjectValidator :AbstractValidator<EditProjectCommand>
    {
        public EditProjectValidator() 
        {
            RuleFor(o=>o.ID).NotEmpty().WithMessage("ID không được trống");

            RuleFor(o => o.Thumbnail)
                .Must(o => o ==null || ImgValidator.ValidateImg(o))
                .WithMessage("Định dạng file ảnh Thumbnail không được hỗ trợ");

            RuleFor(o => o.Media)
                .Must(o => o ==null || MediaValidator.ValidateMedia(o))
                .WithMessage("Định dạng file trong media không được hỗ trợ hoặc trọng lượng video quá lớn");
        }
    }
}
