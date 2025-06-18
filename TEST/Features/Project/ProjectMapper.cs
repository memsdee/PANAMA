using PANAMA.Features.Project.FindProject;

namespace PANAMA.Features.Project
{
    public static class ProjectMapper
    {
        public static FindProjectResponse MapToResponse(PANAMA.Models.Project project)
        {
            return new FindProjectResponse
            {
                Id = project.IdProject,
                Title = project.Title,
                Category = project.Category,
                Images = project.Media.Where(p => p.FileType == "img").Select(i => i.FilePath).ToArray(),
                Time = project.TimeProject.ToString("dd/MM/yyyy"),
                Video = GetVideoResponse(project),
                Description = project.DescProject
            };
        }

        private static Video GetVideoResponse(PANAMA.Models.Project project)
        {
            var videoMedia = project.Media?.FirstOrDefault(p => p.FileType == "video");

            if (videoMedia != null)
            {
                return new Video
                {
                    Url = videoMedia.FilePath,
                    Thumbnail = project.Thumbnail
                };
            }

            if (!string.IsNullOrEmpty(project.Thumbnail))
            {
                return new Video
                {
                    Url = null,
                    Thumbnail = project.Thumbnail
                };
            }

            return null;
        }
    }
}
