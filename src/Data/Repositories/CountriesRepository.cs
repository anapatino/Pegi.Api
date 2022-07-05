using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class CountriesRepository : Repository<Country>
{
    public CountriesRepository(PegiDbContext context) : base(context)
    {
    }
}
