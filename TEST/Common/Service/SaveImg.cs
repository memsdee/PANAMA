namespace PANAMA.Common.Service
{
    public static class SaveImg
    {
        public static async Task<string> SaveFile(IFormFile img, string title,CancellationToken cancellationToken)
        {
            string thumbnaiPath = @"C:\Users\Admin\Downloads\TEST\TEST\Access\Thumbnail\";

            var fileExt = Path.GetExtension(img.FileName).ToLower();
            var fileName = title.ToLower() + fileExt;
            var filePath = Path.Combine(thumbnaiPath, fileName);
            using (var i = new FileStream(filePath,FileMode.Create))
            {
                await img.CopyToAsync(i,cancellationToken);
            }
            return filePath;
        }
    }
}
