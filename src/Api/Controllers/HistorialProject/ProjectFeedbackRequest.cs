namespace Api.Controllers.HistorialProject;

public record ProjectFeedbackRequest(string? Comment, string? Status, int? Score,string? ProjectCode);
