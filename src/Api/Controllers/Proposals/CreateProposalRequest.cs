using Entities;

namespace Api.Controllers.Proposals;

public record CreateProposalRequest
(
    string Code,
    string Title,
    DateTime Date,
    string ResearchGroup,
    string ApproachProblem,
    string FormulationProblem,
    string JustificationProblem,
    string GeneralObjective,
    string SpecificObjective,
    string Bibliography,
    string CodeEvaluation,
    string Status,
    string Feedback,
    ICollection<Member> Members
);
