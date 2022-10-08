using FluentValidation;
using Kodlama.io.Devs.Application.Features.Auths.Constants;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Login;

/// <summary>
/// Kullanıcı giriş işlemleri için validasyon sınıfı
/// </summary>
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x=>x.UserForLoginDto.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage(AuthMessages.UserEmailIsRequired);
        
        RuleFor(x=>x.UserForLoginDto.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage(AuthMessages.UserPasswordIsRequired);
        
        // RuleFor(x=>x.UserForLoginDto.AuthenticatorCode)
        //     .NotEmpty()
        //     .NotNull()
        //     .WithMessage(AuthMessages.UserAuthenticatorCodeIsRequired);
    }
}