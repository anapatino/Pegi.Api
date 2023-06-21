using Data;
using Data.Repository.shared;
using Entities;



public class ProfessorRepository : Repository<Professor>
{
    public ProfessorRepository(PegiDbContext context) : base(context)
    {
    }
}
