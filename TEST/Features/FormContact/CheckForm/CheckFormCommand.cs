using MediatR;

namespace PANAMA.Features.FormContact.CheckForm
{
    public class CheckFormCommand : IRequest<CheckFormResponse>
    {
        public int Id { get; set; }
    }
}
