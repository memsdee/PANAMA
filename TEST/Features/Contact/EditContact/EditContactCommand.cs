using MediatR;

namespace PANAMA.Features.Contact.EditContact
{
    public class EditContactCommand : IRequest<EditContactResponse>
    {
        public string? StudioAddress { get; set; }

        public string? StudioPhoneNumber { get; set; }

        public string? FanpageName { get; set; }

        public string? FanpageUrl { get; set; }

        public string? MainAddress { get; set; }

        public string? MainPhoneNumber { get; set; }

        public string? AboutText1 { get; set; }

        public string? AboutText2 { get; set; }

        public string? AboutText3 { get; set; }

        public string? FacebookUrl { get; set; }

        public string? YouTubeUrl { get; set; }
    }
}
