using Entities;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.Auth;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService  _authService;
    private readonly UsersService _usersService;

    public AuthController(AuthService authService, UsersService usersService)
    {
        _authService  = authService;
        _usersService = usersService;
    }

    [HttpPost("login")]
    public ActionResult LogIn([FromBody] LoginRequest loginRequest)
    {
        try
        {
            string message = _authService.LogIn(loginRequest.Name,
                loginRequest.Password);
            return Ok(new Response<Void>(message, false));
        }
        catch (AuthException e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }


    [HttpPost("sign-up")]
    public ActionResult SignUp([FromBody] SignUpRequest signUpRequest)
    {
        var user = signUpRequest.Adapt<User>();
        if (_usersService.SaveUser(user))
            return Ok(new Response<Void>("Usuario creado con exito",
                false));

        return BadRequest(
            new Response<Void>("No se pudo registrar el usuario"));
    }
}
