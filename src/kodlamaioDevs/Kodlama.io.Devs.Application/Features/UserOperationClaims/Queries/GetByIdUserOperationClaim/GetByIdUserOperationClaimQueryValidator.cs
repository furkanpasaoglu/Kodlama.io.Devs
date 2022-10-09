using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;

/// <summary>
/// GetById Kullanıcı Operasyon İşlemi Validasyon Sınıfı
/// </summary>
public class GetByIdUserOperationClaimQueryValidator: AbstractValidator<GetByIdUserOperationClaimQuery>
{
    public GetByIdUserOperationClaimQueryValidator()
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