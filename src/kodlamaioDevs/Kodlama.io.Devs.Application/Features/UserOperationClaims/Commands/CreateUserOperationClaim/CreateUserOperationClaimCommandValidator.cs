using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

/// <summary>
/// Kullanıcı Operasyon claim oluşturmak için validasyon kuralları
/// </summary>
public class CreateUserOperationClaimCommandValidator : AbstractValidator<CreateUserOperationClaimCommand>
{
    public CreateUserOperationClaimCommandValidator()
    {
        RuleFor(x=>x.UserId)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserOperationClaimMessages.UserIdIsRequired);
        
        RuleFor(x=>x.OperationClaimId)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserOperationClaimMessages.OperationClaimIdIsRequired);
        
        RuleFor(d => d.UserId)
            .GreaterThan(0)
            .WithMessage(UserOperationClaimMessages.UserIdGreaterThanZero);
        
        RuleFor(d => d.OperationClaimId)
            .GreaterThan(0)
            .WithMessage(UserOperationClaimMessages.OperationClaimIdGreaterThanZero);
    }
}