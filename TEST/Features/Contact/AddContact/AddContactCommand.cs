using MediatR;
using PANAMA.Features.Contact.GetContact;

namespace PANAMA.Features.Contact.AddContact
{
    public class AddContactCommand : IRequest<AddContactResponse>
    {
        public string StudioAddress { get; set; } = null!;

        public string StudioPhoneNumber { get; set; } = null!;

        public string FanpageName { get; set; } = null!;

        public string FanpageUrl { get; set; } = null!;

        public string MainAddress { get; set; } = null!;

        public string MainPhoneNumber { get; set; } = null!;

        public string AboutText1 { get; set; } = null!;

        public string AboutText2 { get; set; } = null!;

        public string AboutText3 { get; set; } = null!;

        public string FacebookUrl { get; set; } = null!;

        public string YouTubeUrl { get; set; } = null!;
    }
}
