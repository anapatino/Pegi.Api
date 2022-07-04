namespace Api.Controllers.Auth;

public record SignUpRequest(string Username, string Password, string Role);
