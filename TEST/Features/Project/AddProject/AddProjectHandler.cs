using MediatR;
using PANAMA.Common.Service;
using PANAMA.Models;
using static PANAMA.Common.Service.SaveMedia;

namespace PANAMA.Features.Project.AddProject
{
    public class AddProjectHandler :IRequestHandler<AddProjectCommand, AddProjectResponse>
    {
        private readonly PanamaContext _dbContext;


        public AddProjectHandler(PanamaContext dbContext, IWebHostEnvironment evn)
        {
            _dbContext = dbContext;
        }

        public async Task<AddProjectResponse> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var isTitle = _dbContext.Projects.Where(o => o.Title == request.Title);
            if (isTitle.Any())
                throw new KeyNotFoundException("Title đã có trong dữ liệu");

            var thumbnailPath = await SaveImg.SaveFile(request.Thumbnail,request.Title,cancellationToken);

            var project = new Models.Project
            {
                Category = request.Category,
                Title = request.Title,
                TimeProject = request.TimeProject,
                DescProject = request.DescProject,
                Thumbnail = thumbnailPath,
            };

            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync(cancellationToken);

            if (request.Media.Any())
            {
                var mediaList = new List<MediaInfor>(await SaveMedia.SaveFileMedia(request.Media,request.Title,cancellationToken));
                foreach (var i in mediaList)
                {
                    var medium = new Models.Medium
                    {
                        FilePath = i.FilePath,
                        FileType = i.FileType,
                        Idproject = project.IdProject
                    };
                    _dbContext.Add(medium);
                   await _dbContext.SaveChangesAsync(cancellationToken);
                }
            }

            return new AddProjectResponse
            {
                Success = true
            };
        }
    }
}
