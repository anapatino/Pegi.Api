using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class ThematicAreasRepository : Repository<ThematicArea>
{
    public ThematicAreasRepository(PegiDbContext context) : base(context)
    {
    }
}
