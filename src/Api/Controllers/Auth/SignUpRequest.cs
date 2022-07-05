namespace Api.Controllers.Auth;

public record SignUpRequest(string Name, string Password, string Role ,string PersonDocument);
