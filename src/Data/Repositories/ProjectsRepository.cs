using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class ProjectsRepository : Repository<Project>
{
    public ProjectsRepository(PegiDbContext context) : base(context)
    {
    }
}
