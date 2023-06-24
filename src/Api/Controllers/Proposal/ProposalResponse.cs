namespace Api.Controllers.Proposal;

public record ProposalResponse(string? Code, string? PersonDocument1,string? PersonDocument2,
    string? Title, DateTime? Date,
    string? InvestigationGroup, string? Approach, string? Justification,
    string? GeneralObjective, string? SpecificObjective,
    string? Bibliographical, string? Status, string? ProposalCode,string? EvaluatorDocument,string? TutorDocument);
