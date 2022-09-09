using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;

/// <summary>
/// Programlama dili silme komutu için validasyon sınıfıdır.
/// </summary>
public class DeleteProgrammingTechnologyCommandValidator : AbstractValidator<DeleteProgrammingTechnologyCommand>
{
    public DeleteProgrammingTechnologyCommandValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingTechnologyConstants.IdIsRequired);
        
        RuleFor(d => d.Id)
            .GreaterThan(0)
            .WithMessage(ProgrammingTechnologyConstants.GreaterThanZero);
    }
}