using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class DepartmentsRepository : Repository<Department>
{
    public DepartmentsRepository(PegiDbContext context) : base(context)
    {
    }
}
