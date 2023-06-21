using Data;
using Data.Repository.shared;
using Entities;


public class HistoryProposalsRepository : Repository<HistoryProposals>
{
    public HistoryProposalsRepository(PegiDbContext context) : base(context)
    {
    }
}
