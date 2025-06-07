using MediatR;
using PANAMA.Models;

namespace PANAMA.Features.FormContact.SendForm
{
    public class SendFormHandler : IRequestHandler<SendFormCommand, SendFormResponse>
    {
        private readonly PanamaContext _dbContext;

        public SendFormHandler(PanamaContext context)
        {
            _dbContext = context;
        }

        public async Task<SendFormResponse> Handle(SendFormCommand request, CancellationToken cancellationToken)
        {
            var form = new Models.FormContact()
            {
                UserEmail = request.UserEmail,
                UserName = request.UserName,
                AreaOfInterest = request.AreaOfInterest,
                Content = request.Content,
                CreatedAt = DateTime.Now
            };
            _dbContext.FormContacts.Add(form);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new SendFormResponse()
            {
                Success = true,
                Id = form.IdForm
            };
        }

    }
}
