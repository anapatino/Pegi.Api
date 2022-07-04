using Entities;

namespace Data;

public class UsersRepository : Repository<User>
{
    public UsersRepository(PegiDbContext context) : base(context)
    {
    }
}
