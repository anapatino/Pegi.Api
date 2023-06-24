namespace Api.Controllers.Project;

public record ProjectRequest(
    string? Content, string? Status, int? Score, string? ProposalCode,string? EvaluatorDocument,string? TutorDocument);
