using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class ProyectFeedBackRepository : Repository<ProyectFeedBack>
{
    public ProyectFeedBackRepository(PegiDbContext context) : base(context)
    {
    }
}
