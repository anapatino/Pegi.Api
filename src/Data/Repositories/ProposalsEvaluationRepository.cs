using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class ProposalsEvaluationRepository : Repository<ProposalEvaluation>
{
    public ProposalsEvaluationRepository(PegiDbContext context) : base(context)
    {
    }
}
