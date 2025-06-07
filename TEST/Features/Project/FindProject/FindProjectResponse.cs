namespace PANAMA.Features.Project.FindProject
{
    public class FindProjectResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string[] Images { get; set; } 
        public string Time { get; set; } = null!;
        public Video Video { get; set; } = null!;
        public string Description { get; set; }  = null!;
    }

        public class Video
        {
            public string Url { get; set; } = null!;
            public string Thumbnail { get; set; } = null!;
        }
}


