namespace Api.Controllers.Proyect;

public record ProyectRequest(string? PersonDocument,
    string? Content, string? Status, int? Score, string? ProposalCode);
