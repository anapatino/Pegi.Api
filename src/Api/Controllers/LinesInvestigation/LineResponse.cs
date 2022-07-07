using Api.Controllers.SublinesInvestigation;

namespace Api.Controllers.LinesInvestigation;

public record LineResponse
(
    string Code,
    string Name,
    ICollection<SublineResponse> SublinesInvestigation
);
