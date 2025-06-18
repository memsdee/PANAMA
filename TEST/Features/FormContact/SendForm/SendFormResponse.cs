namespace PANAMA.Features.FormContact.SendForm
{
    public class SendFormResponse
    {
        public int Id {get;set;}
        public string UserName { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public string AreaOfInterest { get; set; } = null!;

        public string Content { get; set; } = null!;

        public bool StatusCheck { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
