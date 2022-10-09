using FluentValidation;
using Kodlama.io.Devs.Application.Features.OperationClaims.Constants;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

/// <summary>
/// Operasyon claim oluşturmak için validasyon kuralları
/// </summary>
public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
{
    public CreateOperationClaimCommandValidator()
    {
        RuleFor(x=>x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(OperationClaimMessages.NameIsRequired);
    }
}