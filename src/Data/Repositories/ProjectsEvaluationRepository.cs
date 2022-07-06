using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class ProjectsEvaluationRepository : Repository<ProjectEvaluation>
{
    public ProjectsEvaluationRepository(PegiDbContext context) : base(context)
    {
    }
}
