using FluentValidation;

namespace PANAMA.Features.Project.DelProject
{
    public class DelProjectValidator : AbstractValidator<DelProjectCommand>
    {
        public DelProjectValidator()
        {
            RuleFor(o=>o.ID).NotEmpty().WithMessage("ID không được trống");
        }
    }
}
