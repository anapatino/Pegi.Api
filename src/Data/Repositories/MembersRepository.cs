using System.Linq.Expressions;
using Data.Repositories.Shared;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class MembersRepository : Repository<Member>
{
    public MembersRepository(PegiDbContext context) : base(context)
    {
    }

    public override Member? Find(Expression<Func<Member, bool>> predicate)
    {
        return Context.Members
            .Include(student => student.AcademicProgram)
            .FirstOrDefault(predicate);
    }
}
