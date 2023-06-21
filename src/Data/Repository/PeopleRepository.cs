using Data.Repository.shared;
using Entities;

namespace Data.Repository;


public class PeopleRepository : Repository<Person>
{
    public PeopleRepository(PegiDbContext context) : base(context)
    {
    }
}
