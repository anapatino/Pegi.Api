using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class StudentsRepository : Repository<Student>
{
    public StudentsRepository(PegiDbContext context) : base(context)
    {
    }
}
