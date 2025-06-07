namespace PANAMA.Common.Service
{
    public static class SaveMedia
    {   
        public class MediaInfor()
        {
            public string FilePath { get; set; } = null!;
            public string FileType { get; set; } = null!;
        }

        public static async Task<List<MediaInfor>> SaveFileMedia(List<IFormFile> media, string title,CancellationToken cancellationToken)
        {
            List<string> ImgFormat = new() { ".jpg", ".jpeg", ".png", ".bmp", ".tiff", ".webp" };
            List<string> videoFormat = new List<string> { ".mp4", ".avi", ".mov", ".mkv", ".wmv", ".flv", ".webm" };
            var mediaInfor = new List<MediaInfor>();
            string mediaFolderPath = @"C:\Users\Admin\Downloads\TEST\TEST\Access\Media\";
            int p = 1;
            foreach (var i in media)
            {   
                var fileExt = Path.GetExtension(i.FileName).ToLower();
                var fileType = ImgFormat.Contains(fileExt) ? "img" : "video";
                var fileName = title.ToLower() + "_" + p + fileExt; 
                var filePath = Path.Combine(mediaFolderPath,fileName);
                using (var o = new FileStream(filePath, FileMode.Create))
                {
                    await i.CopyToAsync(o,cancellationToken);
                }
                p++;
                mediaInfor.Add(new MediaInfor()
                {
                    FilePath = filePath,
                    FileType = fileType
                });
            }
            return mediaInfor;
        }
    }
}
