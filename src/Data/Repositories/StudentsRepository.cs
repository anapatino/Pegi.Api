using System.Linq.Expressions;
using Data.Repositories.Shared;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class StudentsRepository : Repository<Student>
{
    public StudentsRepository(PegiDbContext context) : base(context)
    {
    }

    public override Student? Find(Expression<Func<Student, bool>> predicate)
    {
        return Context.Students
            .Include(student => student.ProgramCode)
            .FirstOrDefault(predicate);
    }
}
