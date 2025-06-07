using MediatR;
using PANAMA.Features.Project.FindProject;

namespace PANAMA.Features.Project.GetAllProject
{
    public class GetProjectCategoryQuery : IRequest<List<FindProjectResponse>>
    {
        public string? category { get; set; }
    }
}
