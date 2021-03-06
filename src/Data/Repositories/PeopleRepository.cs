using System.Linq.Expressions;
using Data.Repositories.Shared;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class PeopleRepository : Repository<Person>
{
    public PeopleRepository(PegiDbContext context) : base(context)
    {
    }

    public override Person? Find(Expression<Func<Person, bool>> predicate)
    {
        return Context.People
            .Include(person => person.Nationality)
            .Include(person => person.AcademicProgram)
            .Include(person => person.Studies)
            .ThenInclude(study => study.City)
            .Include(person => person.Experiences)
            .ThenInclude(experience => experience.City)
            .FirstOrDefault(predicate);
    }
}
