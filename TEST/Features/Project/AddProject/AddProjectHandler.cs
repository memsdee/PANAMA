using MediatR;
using Microsoft.EntityFrameworkCore;
using PANAMA.Features.Project.FindProject;
using PANAMA.Models;
namespace PANAMA.Features.Project.AddProject
{
    public class AddProjectHandler :IRequestHandler<AddProjectCommand, FindProjectResponse>
    {
        private readonly PanamaContext _dbContext;


        public AddProjectHandler(PanamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FindProjectResponse> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {

            var project = new Models.Project
            {
                Category = request.Category,
                Title = request.Title,
                TimeProject = request.TimeProject,
                DescProject = request.DescProject,
                Thumbnail = request.Thumbnail,
            };

            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync(cancellationToken);

            foreach (var o in request.Media)
            {
                string isVideo = o.IsVideo ? "video" : "image";
                var medium = new Models.Medium
                {
                    FilePath = o.FilePath,
                    FileType = isVideo,
                    Idproject = project.IdProject
                };
                _dbContext.Media.Add(medium);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            project = await _dbContext.Projects.Include(p => p.Media).FirstOrDefaultAsync(p => p.IdProject == project.IdProject, cancellationToken);

            return ProjectMapper.MapToResponse(project);
        }
    }
}
