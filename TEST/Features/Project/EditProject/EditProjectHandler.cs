using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PANAMA.Features.FormContact.GetAllForm;
using PANAMA.Models;
using PANAMA.Common;

using PANAMA.Features.Project.FindProject;

namespace PANAMA.Features.Project.EditProject
{
    public class EditProjectHandler : IRequestHandler<EditProjectCommand, FindProjectResponse>
    {
        private readonly PanamaContext _dbContext;

        public EditProjectHandler(PanamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FindProjectResponse> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.Include(o=>o.Media).FirstOrDefaultAsync(o => o.IdProject == request.ID, cancellationToken);

            if (project == null) throw new KeyNotFoundException("Không tìm thấy project hợp lệ");

            if (!string.IsNullOrEmpty(request.Title)) project.Title = request.Title;

            if (!string.IsNullOrEmpty(request.Category)) project.Category = request.Category;        

            if (!string.IsNullOrEmpty(request.DescProject)) project.DescProject = request.DescProject;

            if (request.TimeProject != null) project.TimeProject = request.TimeProject.Value;

            if (!string.IsNullOrEmpty(request.Thumbnail)) project.Thumbnail = request.Thumbnail;

            if (request.Media.Any())
            {
                _dbContext.Media.RemoveRange(project.Media);

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
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync(cancellationToken);

            }
            return ProjectMapper.MapToResponse(project);


        }
    }
}
