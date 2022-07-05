using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class TeachersRepository:Repository<Teacher>
{
    public TeachersRepository(PegiDbContext context) : base(context)
    {
    }
}
