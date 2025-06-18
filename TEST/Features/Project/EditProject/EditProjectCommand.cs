using MediatR;
using PANAMA.Features.Project.FindProject;

namespace PANAMA.Features.Project.EditProject
{
    public class EditProjectCommand :IRequest<FindProjectResponse>
    {
        public int ID { get; set; } 
        public string? Category { get; set; }

        public string? Title { get; set; } 

        public DateTime? TimeProject { get; set; }

        public string? DescProject { get; set; } 

        public string? Thumbnail { get; set; }

        public List<Mediax>? Media { get; set; }
    }
    public record Mediax
    {
        public string FilePath { get; set; }
        public bool IsVideo { get; set; } = false;
    }
}
