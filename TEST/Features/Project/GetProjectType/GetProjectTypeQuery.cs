using MediatR;
using PANAMA.Features.Project.FindProject;

namespace PANAMA.Features.Project.GetProjectType
{
    public class GetProjectTypeQuery : IRequest<List<FindProjectResponse>>
    {
        public string? type { get; set; }
    }
}
