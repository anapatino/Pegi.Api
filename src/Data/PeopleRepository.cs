using Entities;

namespace Data;

public class PeopleRepository: Repository<Person>
{
    public PeopleRepository(PegiDbContext context) : base(context)
    {
    }
}
