using MediatR;

namespace PANAMA.Features.Project.DelProject
{
    public class DelProjectCommand : IRequest<DelProjectResponse>
    {
        public int ID { get; set; }
    }
}
