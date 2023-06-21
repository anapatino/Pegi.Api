using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class UsersRepository : Repository<User>
{
    public UsersRepository(PegiDbContext context) : base(context)
    {
    }
}
