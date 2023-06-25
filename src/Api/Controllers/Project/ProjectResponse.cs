namespace Api.Controllers.Project;

public record ProjectResponse(string? Code, string? PersonDocument,string? ProfessorDocument,
    string? Content, string? Status, int? Score, string? ProposalCode);
