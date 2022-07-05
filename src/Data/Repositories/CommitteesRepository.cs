using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class CommitteesRepository : Repository<Committee>
{
    public CommitteesRepository(PegiDbContext context) : base(context)
    {
    }
}
