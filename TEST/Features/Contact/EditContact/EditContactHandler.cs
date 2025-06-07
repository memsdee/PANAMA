using MediatR;
using PANAMA.Models;
using Microsoft.Extensions.Caching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

namespace PANAMA.Features.Contact.EditContact
{
    public class EditContactHandler : IRequestHandler<EditContactCommand, EditContactResponse>
    {
        private readonly PanamaContext _dbContext;
        private readonly IMemoryCache _cache;

        public EditContactHandler(PanamaContext dbContext, IMemoryCache cacha)
        {
            _dbContext = dbContext;
            _cache = cacha;
        }

        public async Task<EditContactResponse> Handle(EditContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(cancellationToken);
            if (contact == null)
                throw new KeyNotFoundException("Không tìm contact hợp lệ");

            if (request.StudioAddress != null) contact.StudioAddress = request.StudioAddress;
            if (request.StudioPhoneNumber != null) contact.StudioPhoneNumber = request.StudioPhoneNumber;
            if (request.FanpageName != null) contact.FanpageName = request.FanpageName;
            if (request.FanpageUrl != null) contact.FanpageUrl = request.FanpageUrl;
            if (request.MainAddress != null) contact.MainAddress = request.MainAddress;
            if (request.MainPhoneNumber != null) contact.MainPhoneNumber = request.MainPhoneNumber;
            if (request.AboutText1 != null) contact.AboutText1 = request.AboutText1;
            if (request.AboutText2 != null) contact.AboutText2 = request.AboutText2;
            if (request.AboutText3 != null) contact.AboutText3 = request.AboutText3;
            if (request.FacebookUrl != null) contact.FacebookUrl = request.FacebookUrl;
            if (request.YouTubeUrl != null) contact.YouTubeUrl = request.YouTubeUrl;

            _cache.Remove(0000);
            _cache.Set(0000, contact);

            _dbContext.Update(contact);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new EditContactResponse()
            {
                Success = true
            };
        }
    }
}
