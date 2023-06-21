using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class StudiesRespository : Repository<Study>
{
    public StudiesRespository(PegiDbContext context) : base(context)
    {
    }
}
