using FluentValidation;


namespace PANAMA.Features.Project.EditProject
{
    public class EditProjectValidator :AbstractValidator<EditProjectCommand>
    {
        public EditProjectValidator() 
        {
            RuleFor(o=>o.ID).NotEmpty().WithMessage("ID không được trống");
        }
    }
}
