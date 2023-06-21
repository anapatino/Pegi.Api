using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class ResearchSubLinesRepository : Repository<ResearchSubline>
{
    public ResearchSubLinesRepository(PegiDbContext context) : base(context)
    {
    }
}
