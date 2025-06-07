using MediatR;

namespace PANAMA.Features.Project.EditProject
{
    public class EditProjectCommand :IRequest<EditProjectResponse>
    {
        public int ID { get; set; } 
        public string? Category { get; set; }

        public string? Title { get; set; }

        public DateTime? TimeProject { get; set; }

        public string? DescProject { get; set; }

        public IFormFile? Thumbnail { get; set; } 

        public List<IFormFile>? Media { get; set; }
    }
}
