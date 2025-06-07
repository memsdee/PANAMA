using MediatR;
using PANAMA.Models;
using Microsoft.Extensions.Caching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

namespace PANAMA.Features.Contact.GetContact
{
    public class GetContactHandler : IRequestHandler<GetContactQuery, GetContactResponse>
    {
        private readonly PanamaContext _dbContext;
        private readonly IMemoryCache _cache;

        public GetContactHandler(PanamaContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public async Task<GetContactResponse> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            if(_cache.TryGetValue(0000, out GetContactResponse x))
                return x;

            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(cancellationToken);

            if (contact == null)
                throw new KeyNotFoundException("Không có dữ liệu");

            _cache.Set(0000, contact);

            return new GetContactResponse()
            {
                Social = new Social
                {
                    Facebook = contact.FacebookUrl,
                    Youtube = contact.YouTubeUrl
                },
                Address = new Address
                {
                    Studio = new Studio
                    {
                        Address = contact.StudioAddress,
                        Number = contact.StudioPhoneNumber,
                        NameFanpage = contact.FanpageName,
                        LinkFanpage = contact.FanpageUrl
                    },
                    Main = new Main
                    {
                        Address = contact.MainAddress,
                        Number = contact.MainPhoneNumber
                    }
                },
                About = new About
                {
                    Text1 = contact.AboutText1,
                    Text2 = contact.AboutText2,
                    Text3 = contact.AboutText3
                }
            };
        }
    }
}
