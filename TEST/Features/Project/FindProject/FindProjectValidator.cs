using FluentValidation;

namespace PANAMA.Features.Project.FindProject
{
    public class FindProjectValidator :AbstractValidator<FindProjectQuery>
    {
        public FindProjectValidator()
        {
            RuleFor(o => o.Title).NotEmpty().WithMessage("Title không được trống");
        }
    }
}
