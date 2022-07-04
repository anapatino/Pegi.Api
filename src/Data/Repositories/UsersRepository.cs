using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class UsersRepository : Repository<User>
{
    public UsersRepository(PegiDbContext context) : base(context)
    {
    }
}
