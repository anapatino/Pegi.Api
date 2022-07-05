using Entities;

namespace Api.Controllers.LinesInvestigation;

public record LineResponse
(
    string Code,
    string Name,
    ICollection<SublineInvestigation> SublinesInvestigation
);
