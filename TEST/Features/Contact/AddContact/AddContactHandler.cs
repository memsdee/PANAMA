using MediatR;
using PANAMA.Models;
using Microsoft.Extensions.Caching.Memory;
using PANAMA.Features.Contact.GetContact;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PANAMA.Features.Contact.AddContact
{
    public class AddContactHandler : IRequestHandler<AddContactCommand, AddContactResponse>
    {
        private readonly PanamaContext _dbContext;
        private readonly IMemoryCache _cache;

        public AddContactHandler(PanamaContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public async Task<AddContactResponse> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Models.Contact
            {
                StudioAddress = request.StudioAddress,
                StudioPhoneNumber = request.StudioPhoneNumber,
                FanpageName = request.FanpageName,
                FanpageUrl = request.FanpageUrl,
                MainAddress = request.MainAddress,
                MainPhoneNumber = request.MainPhoneNumber,
                AboutText1 = request.AboutText1, 
                AboutText2 = request.AboutText2,
                AboutText3 = request.AboutText3,
                FacebookUrl = request.FacebookUrl,
                YouTubeUrl = request.YouTubeUrl
            };

            _cache.Set(0000,contact);

            _dbContext.Add(contact);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new AddContactResponse
            {
                Id = contact.Id,
                Success = true
            }; ;

        }
    }
    }

