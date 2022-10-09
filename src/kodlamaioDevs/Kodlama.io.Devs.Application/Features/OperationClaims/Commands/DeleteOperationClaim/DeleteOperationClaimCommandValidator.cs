using FluentValidation;
using Kodlama.io.Devs.Application.Features.OperationClaims.Constants;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

/// <summary>
/// Operasyon claim silmek için validasyon kuralları
/// </summary>
public class DeleteOperationClaimCommandValidator : AbstractValidator<DeleteOperationClaimCommand>
{
    public DeleteOperationClaimCommandValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(OperationClaimMessages.IdIsRequired);
        
        RuleFor(d => d.Id)
            .GreaterThan(0)
            .WithMessage(OperationClaimMessages.GreaterThanZero);
    }
}