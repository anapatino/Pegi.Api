namespace Api.Controllers.Project;

public record ProjectRequest(string? PersonDocument,
    string? Content, string? Status, int? Score, string? ProposalCode);
