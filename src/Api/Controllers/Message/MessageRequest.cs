namespace Api.Controllers.Message;

public record MessageRequest
(
    string? PersonDocument,
    string? Name,
    string? Content,
    DateTime? Date
 );
