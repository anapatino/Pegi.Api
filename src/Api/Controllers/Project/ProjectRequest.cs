namespace Api.Controllers.Project;

public record ProjectRequest(string? personDocument1, string? personDocument2, string status, int score, string proposalCode);
