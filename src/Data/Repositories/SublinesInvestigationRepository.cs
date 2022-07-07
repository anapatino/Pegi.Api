using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class SublinesInvestigationRepository : Repository<InvestigationSubLine>
{
    public SublinesInvestigationRepository(PegiDbContext context) : base(
        context)
    {
    }
}
