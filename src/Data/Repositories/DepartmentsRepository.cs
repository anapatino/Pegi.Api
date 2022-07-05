using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class DepartmentsRepository : Repository<Department>
{
    public DepartmentsRepository(PegiDbContext context) : base(context)
    {
    }
}
