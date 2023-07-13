using Data.Repository.shared;
using Entities;
namespace Data.Repository;

public class ResearchGroupRepository: Repository<ResearchGroup>
{
    public ResearchGroupRepository(PegiDbContext context) : base(context)
    {

    }
}
