using MediatR;

namespace PANAMA.Features.Project.FindProject
{
    public class FindProjectQuery : IRequest<List<FindProjectResponse>>
    {
        public string Title { get; set; } = null!;
    }
}
