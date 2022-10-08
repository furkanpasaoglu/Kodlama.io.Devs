using FluentValidation;
using Kodlama.io.Devs.Application.Features.Auths.Constants;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Register;

/// <summary>
/// Kullanıcı kayıt işlemleri için validasyon sınıfı
/// </summary>
public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x=>x.UserForRegisterDto.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage(AuthMessages.UserEmailIsRequired);
        
        RuleFor(x=>x.UserForRegisterDto.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage(AuthMessages.UserPasswordIsRequired);
        
        RuleFor(x=>x.UserForRegisterDto.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage(AuthMessages.UserFirstNameIsRequired);
        
        RuleFor(x=>x.UserForRegisterDto.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage(AuthMessages.UserLastNameIsRequired);
    }
}