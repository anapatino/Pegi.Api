using Api.Controllers.ThematicAreas;

namespace Api.Controllers.SublinesInvestigation;

public record SublineResponse
(
    int Code,
    string Name,
    ICollection<ThematicAreaResponse> ThematicAreas
);
