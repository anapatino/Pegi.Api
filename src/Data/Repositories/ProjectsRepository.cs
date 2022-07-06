using System.Linq.Expressions;
using Data.Repositories.Shared;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectsRepository : Repository<Project>
{
    public ProjectsRepository(PegiDbContext context) : base(context)
    {
    }

    public override Project? Find(Expression<Func<Project, bool>> predicate)
    {
        return Context.Projects
            .Include(project => project.ProposalCode)
            .FirstOrDefault(predicate);
    }
}
