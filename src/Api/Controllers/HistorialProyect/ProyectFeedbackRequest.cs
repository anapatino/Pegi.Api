namespace Api.Controllers.HistorialProyect;

public record ProyectFeedbackRequest(string? Comment, string? Status, int? Score,string? ProyectCode);
