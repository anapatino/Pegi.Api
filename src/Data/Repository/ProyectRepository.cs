using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class ProyectRepository : Repository<Proyect>
{
    public ProyectRepository(PegiDbContext context) : base(context)
    {
    }
}
