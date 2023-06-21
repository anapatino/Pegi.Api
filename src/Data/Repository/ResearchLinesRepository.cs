using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class ResearchLinesRepository : Repository<ResearchLine>
{
    public ResearchLinesRepository(PegiDbContext context) : base(context)
    {
    }
}
