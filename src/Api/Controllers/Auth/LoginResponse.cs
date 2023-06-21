using Api.Controllers.People;
using Entities;

namespace Api.Controllers.Auth;

public record LoginResponse(string Name,string? Role,PersonResponse Person);
