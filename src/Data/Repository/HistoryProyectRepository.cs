using Data;
using Data.Repository.shared;
using Entities;



public class HistoryProyectRepository : Repository<HistoryProyect>
{
    public HistoryProyectRepository(PegiDbContext context) : base(context)
    {
    }
}
