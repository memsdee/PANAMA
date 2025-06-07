using MediatR;

namespace PANAMA.Features.Project.AddProject
{
    public record AddProjectCommand : IRequest<AddProjectResponse>
    {
        public string Category { get; set; } = null!;

        public string Title { get; set; } = null!;

        public DateTime TimeProject { get; set; }

        public string DescProject { get; set; } = null!;

        public IFormFile Thumbnail { get; set; } = null!;

        public List<IFormFile> Media { get; set; } = null!;
    }
}
