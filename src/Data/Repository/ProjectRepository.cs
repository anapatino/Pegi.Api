using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class ProjectRepository : Repository<Project>
{
    public ProjectRepository(PegiDbContext context) : base(context)
    {
    }
}
