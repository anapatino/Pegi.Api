using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class CitiesRepository : Repository<City>
{
    public CitiesRepository(PegiDbContext context) : base(context)
    {
    }
}
