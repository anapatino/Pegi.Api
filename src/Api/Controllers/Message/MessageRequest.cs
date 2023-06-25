namespace Api.Controllers.Message;

public record MessageRequest
(
    string? Code,
    string? Name,
    string? Content,
    DateTime? Date
 );
