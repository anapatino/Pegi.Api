using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class ProposalFeedBackRepository : Repository<ProposalFeedBack>
{
    public ProposalFeedBackRepository(PegiDbContext context) : base(context)
    {
    }
}
