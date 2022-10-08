using Core.Security.Dtos;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Auths.Commands.Login;
using Kodlama.io.Devs.Application.Features.Auths.Commands.Register;
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
    /// <param name="userForRegisterDto">Kullanıcı kayıt bilgileri.</param>
    /// <returns>Kullanıcı kayıt işleminin sonucunu döndürür.</returns>
    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
    {
        var registerCommand = new RegisterCommand
        {
            UserForRegisterDto = userForRegisterDto,
            IpAddress = GetIpAddress()
        };
        
        var result = await Mediator!.Send(registerCommand);
        SetRefreshTokenToCookie(result.RefreshToken);
        return Created("", result.AccessToken);
    }
    
    /// <summary>
    /// Kullanıcı giriş işlemini yapar.
    /// </summary>
    /// <param name="userForLoginDto">Kullanıcı giriş bilgileri.</param>
    /// <returns>Kullanıcı giriş işleminin sonucunu döndürür.</returns>
    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {
        var loginCommand = new LoginCommand
        {
            UserForLoginDto = userForLoginDto,
            IpAddress = GetIpAddress()
        };
        
        var result = await Mediator!.Send(loginCommand);
        SetRefreshTokenToCookie(result.RefreshToken);
        return Created("", result.AccessToken);
    }
    
    /// <summary>
    /// Çerez'e refresh token ekler.
    /// </summary>
    private void SetRefreshTokenToCookie(RefreshToken refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.Now.AddDays(7),
        };
        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }
}