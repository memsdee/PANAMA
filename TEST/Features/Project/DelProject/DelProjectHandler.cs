using MediatR;
using Microsoft.EntityFrameworkCore;
using PANAMA.Features.Project.EditProject;
using PANAMA.Models;

namespace PANAMA.Features.Project.DelProject
{
    public class DelProjectHandler : IRequestHandler<DelProjectCommand, DelProjectResponse>
    {
        private readonly PanamaContext _dbContext;

        public DelProjectHandler(PanamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DelProjectResponse> Handle(DelProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(o=>o.IdProject==request.ID);
            if (project==null)
                throw new KeyNotFoundException("Không có project hợp lệ");

            _dbContext.Remove(project);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new DelProjectResponse()
            {
                Sucess = true
            };
        }
    }
}
