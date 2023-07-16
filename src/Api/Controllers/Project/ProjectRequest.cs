namespace Api.Controllers.Project;

public record ProjectRequest(string? PersonDocument1,string? PersonDocument2,
    string? Content, string? Status, int? Score, string? ProposalCode);
