namespace Api.Controllers.Message;

public record MessageRequest
(
    string? Code,
    string? PersonDocument,
    string? Name,
    string? Content,
    DateTime? Date
 );
