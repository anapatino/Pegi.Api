namespace Api.Controllers.ResearchLines;

public record CreateSubLineRequest(
    string Code,
    string Name,
    string ResearchLineCode);
