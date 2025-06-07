using System.Linq;
using PANAMA.Common.Validator;

namespace PANAMA.Share.Validator
{
    public static class MediaValidator
    {
        public static bool ValidateMedia(List<IFormFile> request)
        {
            List<string> videoFormat = new List<string> { ".mp4", ".avi", ".mov", ".mkv", ".wmv", ".flv", ".webm" };
            long maxSizeInBytes = 250 * 1024 * 1024;

            foreach (var i in request)
            {
                if (i.Length > maxSizeInBytes)
                    return false;
                var ext = Path.GetExtension(i.FileName).ToLower();
                if (!videoFormat.Contains(ext))
                {
                   bool x = ImgValidator.ValidateImg(i);
                   if (x) continue;
                    return false;
                }
            }
            return true;
        }
    }
}
