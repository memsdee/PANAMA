using MediatR;
using PANAMA.Features.FormContact.SendForm;

namespace PANAMA.Features.FormContact.GetAllForm
{
    public class GetAllFormQuery : IRequest<List<SendFormResponse>>
    {
    }
}
