using Entities;

namespace Data;

public class PersonsRepository: Repository<Person>
{
    public PersonsRepository(PegiDbContext context) : base(context)
    {
    }
}
