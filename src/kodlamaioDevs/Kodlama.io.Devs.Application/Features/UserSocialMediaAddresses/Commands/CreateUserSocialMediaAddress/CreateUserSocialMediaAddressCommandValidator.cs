using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Constants;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress;

/// <summary>
/// Oluşturulacak kullanıcı sosyal medya adresi için gerekli validasyon kuralları
/// </summary>
public class CreateUserSocialMediaAddressCommandValidator : AbstractValidator<CreateUserSocialMediaAddressCommand>
{
    public CreateUserSocialMediaAddressCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserSocialMediaAddressMessages.UserIdIsRequired);

        RuleFor(x => x.GithubUrl)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserSocialMediaAddressMessages.GithubUrlIsRequired);
    }
}