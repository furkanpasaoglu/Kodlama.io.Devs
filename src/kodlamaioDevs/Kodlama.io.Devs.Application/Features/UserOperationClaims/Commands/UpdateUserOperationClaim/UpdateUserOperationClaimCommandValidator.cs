using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

/// <summary>
/// Kullanıcı Operasyon claim güncellemek için validasyon kuralları
/// </summary>
public class UpdateUserOperationClaimCommandValidator : AbstractValidator<UpdateUserOperationClaimCommand>
{
    public UpdateUserOperationClaimCommandValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserOperationClaimMessages.IdIsRequired);
        
        RuleFor(d => d.Id)
            .GreaterThan(0)
            .WithMessage(UserOperationClaimMessages.IdGreaterThanZero);
        
        RuleFor(x=>x.UserId)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserOperationClaimMessages.UserIdIsRequired);
        
        RuleFor(d => d.UserId)
            .GreaterThan(0)
            .WithMessage(UserOperationClaimMessages.UserIdGreaterThanZero);
        
        RuleFor(x=>x.OperationClaimId)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserOperationClaimMessages.OperationClaimIdIsRequired);
        
        RuleFor(d => d.UserId)
            .GreaterThan(0)
            .WithMessage(UserOperationClaimMessages.OperationClaimIdGreaterThanZero);
    }
}