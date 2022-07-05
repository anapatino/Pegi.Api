using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class LinesInvestigationRepository : Repository<LineInvestigation>
{
    public LinesInvestigationRepository(PegiDbContext context) : base(context)
    {
    }
}
