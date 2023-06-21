using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class StudentsRepository : Repository<Student>
{
    public StudentsRepository(PegiDbContext context) : base(context)
    {
    }
}
