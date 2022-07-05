using Entities;

namespace Api.Controllers.SublinesInvestigation;

public record CreateSublineRequest
(
    string Code,
    string Name ,
    ICollection<ThematicArea> ThematicAreas
);

