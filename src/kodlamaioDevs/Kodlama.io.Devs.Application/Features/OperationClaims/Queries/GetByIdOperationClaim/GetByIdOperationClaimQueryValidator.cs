using FluentValidation;
using Kodlama.io.Devs.Application.Features.OperationClaims.Constants;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;

/// <summary>
/// Operasyon Claim GetById için validasyon sınıfı
/// </summary>
public class GetByIdOperationClaimQueryValidator : AbstractValidator<GetByIdOperationClaimQuery>
{
    public GetByIdOperationClaimQueryValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(OperationClaimMessages.IdIsRequired);
        
        RuleFor(p=>p.Id)
            .GreaterThan(0).WithMessage(OperationClaimMessages.GreaterThanZero);
    }
}