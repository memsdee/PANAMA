using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PANAMA.Features.FormContact.GetAllForm;
using PANAMA.Models;
using PANAMA.Common;
using PANAMA.Common.Service;
using static PANAMA.Common.Service.SaveMedia;

namespace PANAMA.Features.Project.EditProject
{
    public class EditProjectHandler : IRequestHandler<EditProjectCommand, EditProjectResponse>
    {
        private readonly PanamaContext _dbContext;

        public EditProjectHandler(PanamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EditProjectResponse> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.Include(o=>o.Media).FirstOrDefaultAsync(o => o.IdProject == request.ID, cancellationToken);

            if (project == null) throw new KeyNotFoundException("Không tìm thấy project hợp lệ");          

            if (!string.IsNullOrEmpty(request.Category)) project.Category = request.Category;        

            if (!string.IsNullOrEmpty(request.DescProject)) project.DescProject = request.DescProject;

            if (request.TimeProject != null) project.TimeProject = request.TimeProject.Value;

            if (request.Thumbnail != null && File.Exists(project.Thumbnail))
            {
                File.Delete(project.Thumbnail);
                var filePath = await SaveImg.SaveFile(request.Thumbnail, project.Title, cancellationToken);
                project.Thumbnail = filePath;
            }

            if (request.Media != null)
            {
                List<MediaInfor> mediaI4 = request.Title == null ?  
                    new List<MediaInfor>(await SaveMedia.SaveFileMedia(request.Media, project.Title, cancellationToken)) :
                    mediaI4 = new List<MediaInfor>(await SaveMedia.SaveFileMedia(request.Media, request.Title, cancellationToken));

                _dbContext.Media.RemoveRange(project.Media);
               foreach (var x in project.Media)
               {
                    if (!string.IsNullOrEmpty(x.FilePath) && File.Exists(x.FilePath))
                    File.Delete(x.FilePath);
               }
                foreach (var x in mediaI4)
                {   
                    var medium = new Models.Medium
                    {
                        FilePath = x.FilePath,
                        FileType = x.FileType,
                        Idproject = project.IdProject
                    };
                    _dbContext.Media.Add(medium);
                }
            }

            if (!string.IsNullOrEmpty(request.Title))
            {
                var isTitle = _dbContext.Projects.Where(o => o.Title == request.Title);
                if (isTitle.Any())
                    throw new KeyNotFoundException("Title đã có trong dữ liệu");
               
                var oldThumbnailPath = Path.GetDirectoryName(project.Thumbnail);
                var thumbnailName = request.Title + Path.GetExtension(project.Thumbnail);
                var newThumbnail = Path.Combine(oldThumbnailPath, thumbnailName);
                File.Move(project.Thumbnail, newThumbnail);
                project.Thumbnail = newThumbnail;

               if (request.Media==null)
                {
                    var oldMediaPath = project.Media.Where(m => !string.IsNullOrEmpty(m.FilePath)).Select(m => m.FilePath).ToList();
                    int sum = 1;
                    foreach (var i in oldMediaPath)
                    {
                        var oldPath = Path.GetDirectoryName(i);
                        var mediaName = request.Title + "_" + sum + Path.GetExtension(i);
                        var newMedia = Path.Combine(oldPath, mediaName);
                        File.Move(i, newMedia);
                        var media = project.Media.FirstOrDefault(m => m.FilePath == i);
                        if (media != null)
                        {
                            media.FilePath = newMedia;
                            _dbContext.Media.Update(media);
                        }
                        sum++;
                    }
                }

                project.Title = request.Title;
            }

            _dbContext.Projects.Update(project);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new EditProjectResponse
            {
                Success = true
            };
        }
    }
}
