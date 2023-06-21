using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class ProposalRepository : Repository<Proposal>
{
    public ProposalRepository(PegiDbContext context) : base(context)
    {
    }
}
