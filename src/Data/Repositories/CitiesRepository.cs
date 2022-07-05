using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class CitiesRepository : Repository<City>
{
    public CitiesRepository(PegiDbContext context) : base(context)
    {
    }
}
