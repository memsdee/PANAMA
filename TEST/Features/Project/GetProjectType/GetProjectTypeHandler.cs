using MediatR;
using Microsoft.EntityFrameworkCore;
using PANAMA.Features.Project.FindProject;
using PANAMA.Models;

namespace PANAMA.Features.Project.GetProjectType
{
    public class GetProjectTypeHandler : IRequestHandler<GetProjectTypeQuery, List<FindProjectResponse>>
    {
        private readonly PanamaContext _dbContext;

        public GetProjectTypeHandler(PanamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FindProjectResponse>> Handle(GetProjectTypeQuery request, CancellationToken cancellationToken)
        {
            var projects = _dbContext.Projects
                .Include(p => p.Media).AsQueryable();

            if (!projects.Any())
                throw new KeyNotFoundException("Không có project nào");

            if (!string.IsNullOrEmpty(request.type))
            {
                var project_1 = projects.Where(o => o.Media.Any(p=>p.FileType == request.type.ToLower()));
                if (!project_1.Any())
                    throw new KeyNotFoundException("Không có project nào có: " + request.type);
                var result = await project_1.ToListAsync(cancellationToken);
                return result.Select(ProjectMapper.MapToResponse).ToList();
            }

            var all = await projects.ToListAsync(cancellationToken);
            return all.Select(ProjectMapper.MapToResponse).ToList();
        }
    }
}
