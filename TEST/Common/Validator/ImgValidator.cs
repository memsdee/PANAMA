namespace PANAMA.Common.Validator
{
    public static class ImgValidator
    {
        public static bool ValidateImg(IFormFile img)
        {
            List<string> ImgFormat = new() { ".jpg", ".jpeg", ".png", ".bmp", ".tiff", ".webp" };

            var imgExt = Path.GetExtension(img.FileName).ToLower();

            if (!ImgFormat.Contains(imgExt))
                return false;
            return true;
        }
    }
}
