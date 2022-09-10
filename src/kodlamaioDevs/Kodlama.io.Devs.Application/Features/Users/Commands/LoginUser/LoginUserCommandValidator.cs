using FluentValidation;
using Kodlama.io.Devs.Application.Features.Users.Constants;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.LoginUser;

/// <summary>
/// Kullanıcılar için giriş validasyon kuralları
/// </summary>
public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserMessages.EmailAddressIsRequired)
            .EmailAddress().WithMessage(UserMessages.EmailAddressIsNotValid);

        RuleFor(p => p.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserMessages.PasswordIsRequired);
    }
}