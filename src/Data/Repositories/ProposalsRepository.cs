using System.Linq.Expressions;
using Data.Repositories.Shared;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProposalsRepository : Repository<Proposal>
{
    public ProposalsRepository(PegiDbContext context) : base(context)
    {
    }

    public override Proposal? Find(Expression<Func<Proposal, bool>> predicate)
    {
        return Context.Proposals
            .Include(proposal => proposal.Students)
            .FirstOrDefault(predicate);
    }
}
