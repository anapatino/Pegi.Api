namespace Api.Controllers.Message;

public record MessageResponse
(
    string? Code,
    string? PersonDocument,
    string? Name,
    string? Content,
    DateTime? Date
);
