using MediatR;
using Microsoft.EntityFrameworkCore;
using PANAMA.Features.Project.FindProject;
using PANAMA.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PANAMA.Features.Project.GetAllProject
{
    public class GetProjectCategoryHandler : IRequestHandler<GetProjectCategoryQuery,List<FindProjectResponse>>
    {
        private readonly PanamaContext _dbContext;

        public GetProjectCategoryHandler(PanamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FindProjectResponse>> Handle(GetProjectCategoryQuery request, CancellationToken cancellationToken)
        {
            var projects = _dbContext.Projects
                .Include(p => p.Media).AsQueryable();

            if (!projects.Any())
                throw new KeyNotFoundException("Không có project nào");

            if (!string.IsNullOrEmpty(request.category))
            {
                var project_1 = projects.Where(o => o.Category == request.category.ToLower());
                if (!project_1.Any())
                    throw new KeyNotFoundException("Không có project nào có: " +request.category);
                var result = await project_1.ToListAsync(cancellationToken);
                return result.Select(ProjectMapper.MapToResponse).ToList();
            }

            var all = await projects.ToListAsync(cancellationToken);
            return all.Select(ProjectMapper.MapToResponse).ToList();

        }
    }
}
