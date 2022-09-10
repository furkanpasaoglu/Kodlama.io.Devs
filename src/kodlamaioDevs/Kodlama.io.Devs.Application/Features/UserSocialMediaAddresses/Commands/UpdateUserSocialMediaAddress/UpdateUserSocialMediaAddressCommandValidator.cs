using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Constants;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress;

/// <summary>
/// Güncellenecek kullanıcı sosyal medya adresi için gerekli validasyon kuralları
/// </summary>
public class UpdateUserSocialMediaAddressCommandValidator : AbstractValidator<UpdateUserSocialMediaAddressCommand>
{
    public UpdateUserSocialMediaAddressCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserSocialMediaAddressMessages.IdIsRequired);

        RuleFor(p => p.UserId)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserSocialMediaAddressMessages.UserIdIsRequired);

        RuleFor(p => p.GithubUrl)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserSocialMediaAddressMessages.GithubUrlIsRequired);
    }
}