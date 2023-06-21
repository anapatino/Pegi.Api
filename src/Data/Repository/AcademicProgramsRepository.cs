using Data.Repository.shared;
using Entities;

namespace Data.Repository;

public class AcademicProgramsRepository : Repository<AcademicProgram>
{
    public AcademicProgramsRepository(PegiDbContext context) : base(context)
    {
    }
}
