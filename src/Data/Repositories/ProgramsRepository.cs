using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class ProgramsRepository : Repository<Program>
{
    public ProgramsRepository(PegiDbContext context) : base(context)
    {
    }
}
