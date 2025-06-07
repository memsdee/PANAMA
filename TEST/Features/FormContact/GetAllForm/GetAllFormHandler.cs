using MediatR;
using PANAMA.Features.FormContact.SendForm;
using PANAMA.Models;
using Microsoft.EntityFrameworkCore;

namespace PANAMA.Features.FormContact.GetAllForm
{
    public class GetAllFormHandler : IRequestHandler<GetAllFormQuery, List<GetAllFormResponse>>
    {
        private readonly PanamaContext _dbContext;

        public GetAllFormHandler(PanamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetAllFormResponse>> Handle(GetAllFormQuery request, CancellationToken cancellationToken)
        {
            var forms = await _dbContext.FormContacts
            .Select(form => new GetAllFormResponse
             {
              IdForm = form.IdForm,
              UserName = form.UserName,
              UserEmail = form.UserEmail,
              AreaOfInterest = form.AreaOfInterest,
              Content = form.Content,
              StatusCheck = form.StatusCheck,
              CreatedAt = form.CreatedAt
              }).ToListAsync(cancellationToken);


            if (!forms.Any())
                    throw new KeyNotFoundException("Không có dữ liệu nào");

                return forms;

        }
    }
}
