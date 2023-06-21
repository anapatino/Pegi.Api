using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class ExperiencesRepository : Repository<Experience>
{
    public ExperiencesRepository(PegiDbContext context) : base(context)
    {
    }
}
