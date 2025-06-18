using MediatR;
using PANAMA.Features.Project.FindProject;

namespace PANAMA.Features.Project.AddProject
{
    public record AddProjectCommand : IRequest<FindProjectResponse>
    {
        public string Category { get; set; } = null!;

        public string Title { get; set; } = null!;

        public DateTime TimeProject { get; set; } 

        public string DescProject { get; set; } = null!;

        public string Thumbnail { get; set; } = null!;

        public List<Media> Media { get; set; } = null!;
    }
    public record Media
    {
        public string FilePath { get; set; } = null!;
        public bool IsVideo { get; set; } = false;
    }
}
