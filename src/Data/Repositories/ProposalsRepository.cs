using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class ProposalsRepository : Repository<Proposal>
{
    public ProposalsRepository(PegiDbContext context) : base(context)
    {
    }
}
