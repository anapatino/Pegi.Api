using Api.Controllers.SublinesInvestigation;

namespace Api.Controllers.LinesInvestigation;

public record CreateLineRequest
(
    string Name,
    ICollection<CreateSublineRequest> InvestigationSubLines
);
