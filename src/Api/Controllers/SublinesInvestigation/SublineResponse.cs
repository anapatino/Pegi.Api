using Entities;

namespace Api.Controllers.SublinesInvestigation;

public record SublineResponse
(
    string Code,
    string Name,
    ICollection<ThematicArea> ThematicAreas
);
