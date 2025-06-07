using MediatR;
using Microsoft.EntityFrameworkCore;
using PANAMA.Features.FormContact.GetAllForm;
using PANAMA.Models;

namespace PANAMA.Features.FormContact.CheckForm
{
    public class CheckFormHandler : IRequestHandler<CheckFormCommand, CheckFormResponse>
    {
        private readonly PanamaContext _dbContext;

        public CheckFormHandler(PanamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CheckFormResponse> Handle(CheckFormCommand request, CancellationToken cancellationToken)
        {
            var form = await _dbContext.FormContacts.FirstOrDefaultAsync(o => o.IdForm == request.Id , cancellationToken);
            if (form == null)
                throw new KeyNotFoundException("Không có form phù hợp");
            form.StatusCheck = true;
            _dbContext.Update(form);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new CheckFormResponse()
            {
                Success = true
            };
        }
    }
}
