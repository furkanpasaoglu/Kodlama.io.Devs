using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

/// <summary>
/// Kullanıcı Operasyon claim silmek için validasyon kuralları
/// </summary>
public class DeleteUserOperationClaimCommandValidator : AbstractValidator<DeleteUserOperationClaimCommand>
{
    public DeleteUserOperationClaimCommandValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserOperationClaimMessages.IdIsRequired);
        
        RuleFor(d => d.Id)
            .GreaterThan(0)
            .WithMessage(UserOperationClaimMessages.IdGreaterThanZero);
    }
}