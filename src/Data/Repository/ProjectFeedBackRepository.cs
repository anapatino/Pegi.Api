using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class ProjectFeedBackRepository : Repository<ProjectFeedBack>
{
    public ProjectFeedBackRepository(PegiDbContext context) : base(context)
    {
    }
}
