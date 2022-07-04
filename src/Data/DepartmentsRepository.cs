using Entities;

namespace Data;

public class DepartmentsRepository: Repository<Department>
{
    public DepartmentsRepository(PegiDbContext context) : base(context)
    {
    }
}
