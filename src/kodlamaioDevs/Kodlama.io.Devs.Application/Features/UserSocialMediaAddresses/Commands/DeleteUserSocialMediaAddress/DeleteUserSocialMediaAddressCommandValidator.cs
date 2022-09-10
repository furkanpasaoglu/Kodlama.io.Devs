using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Constants;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.DeleteUserSocialMediaAddress;

/// <summary>
/// Silinecek kullanıcı sosyal medya adresi için gerekli validasyon kuralları
/// </summary>
public class DeleteUserSocialMediaAddressCommandValidator : AbstractValidator<DeleteUserSocialMediaAddressCommand>
{
    public DeleteUserSocialMediaAddressCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserSocialMediaAddressMessages.IdIsRequired);
            
    }
}