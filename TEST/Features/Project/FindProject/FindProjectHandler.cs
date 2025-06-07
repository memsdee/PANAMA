using MediatR;
using PANAMA.Features.Project.GetAllProject;
using PANAMA.Models;
using Microsoft.EntityFrameworkCore;

namespace PANAMA.Features.Project.FindProject
{
    public class FindProjectHandler : IRequestHandler<FindProjectQuery, List<FindProjectResponse>>
    {
        private readonly PanamaContext _dbContext;

        public FindProjectHandler(PanamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FindProjectResponse>> Handle(FindProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.Include(o=>o.Media)
                .Where(p => p.Title == request.Title).FirstOrDefaultAsync(cancellationToken);

            if (project == null)
            {
                throw new KeyNotFoundException("Không tìm thấy project hợp lệ");
            }

            return new List<FindProjectResponse> { ProjectMapper.MapToResponse(project) };
        }
    }
}
