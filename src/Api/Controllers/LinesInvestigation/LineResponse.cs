using Api.Controllers.SublinesInvestigation;

namespace Api.Controllers.LinesInvestigation;

public record LineResponse
(
    int Code,
    string Name,
    ICollection<SublineResponse> SubLines
);
