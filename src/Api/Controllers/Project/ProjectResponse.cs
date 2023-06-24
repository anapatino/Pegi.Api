namespace Api.Controllers.Project;

public record ProjectResponse(string? Code, string? PersonDocument1,string? PersonDocument2,string? EvaluatorDocument,string? TutorDocument,
    string? Content, string? Status, int? Score, string? ProposalCode);
