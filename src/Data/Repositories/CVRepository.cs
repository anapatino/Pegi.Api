using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class CVRepository : Repository<CV>
{
    public CVRepository(PegiDbContext context) : base(context)
    {
    }
}
