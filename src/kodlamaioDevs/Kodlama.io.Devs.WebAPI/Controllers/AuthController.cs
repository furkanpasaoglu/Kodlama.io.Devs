using Kodlama.io.Devs.Application.Features.Users.Commands.LoginUser;
using Kodlama.io.Devs.Application.Features.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

/// <summary>
/// Kullanıcı için kontrolcüler.
/// </summary>
public class AuthController : BaseController
{
    /// <summary>
    /// Kullanıcı kayıt işlemini yapar.
    /// </summary>
    /// <param name="registerUserCommand">Kullanıcı kayıt komutu.</param>
    /// <returns>Kullanıcı kayıt işleminin sonucunu döndürür.</returns>
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
    {
        var result = await Mediator!.Send(registerUserCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Kullanıcı giriş işlemini yapar.
    /// </summary>
    /// <param name="loginUserCommand">Kullanıcı giriş komutu.</param>
    /// <returns>Kullanıcı giriş işleminin sonucunu döndürür.</returns>
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
    {
        var result = await Mediator!.Send(loginUserCommand);
        return Ok(result);
    }
}