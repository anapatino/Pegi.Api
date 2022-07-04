using Entities;

namespace Data;

public class DepartmentRepository : Repository<Department>
{
    public DepartmentRepository(PegiDbContext context) : base(context)
    {
    }
}
