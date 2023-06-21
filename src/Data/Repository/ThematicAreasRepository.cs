using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class ThematicAreasRepository : Repository<ThematicArea>
{
    public ThematicAreasRepository(PegiDbContext context) : base(context)
    {
    }
}
