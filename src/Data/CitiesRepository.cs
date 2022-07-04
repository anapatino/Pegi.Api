using Entities;

namespace Data;

public class CitiesRepository:Repository<City>
{
    public CitiesRepository(PegiDbContext context) : base(context)
    {
    }
}
