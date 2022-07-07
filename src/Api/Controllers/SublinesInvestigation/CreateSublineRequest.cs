using Api.Controllers.ThematicAreas;

namespace Api.Controllers.SublinesInvestigation;

public record CreateSublineRequest
(
    string Name,
    ICollection<CreateThematicAreaRequest> ThematicAreas
);
