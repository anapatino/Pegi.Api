namespace Api.Controllers.Message;

public record MessageResponse
(
    string? Code,
    string? Name,
    string? Content,
    DateTime? Date
);
