using FluentValidation;
using Kodlama.io.Devs.Application.Features.Users.Constants;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.RegisterUser;

/// <summary>
/// Kullanıcı Kayıt Olmak için kullanılar validasyon sınıfı
/// </summary>
public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserMessages.FirstNameIsRequired);

        RuleFor(p => p.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserMessages.LastNameIsRequired);

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