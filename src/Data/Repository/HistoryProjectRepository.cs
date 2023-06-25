using Data;
using Data.Repository.shared;
using Entities;



public class HistoryProjectRepository : Repository<HistoryProject>
{
    public HistoryProjectRepository(PegiDbContext context) : base(context)
    {
    }
}
