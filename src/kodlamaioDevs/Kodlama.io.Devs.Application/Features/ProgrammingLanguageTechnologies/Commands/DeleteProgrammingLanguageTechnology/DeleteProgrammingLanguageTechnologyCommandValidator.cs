using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology;

/// <summary>
/// Programlama dili silme komutu için validasyon sınıfıdır.
/// </summary>
public class DeleteProgrammingLanguageTechnologyCommandValidator : AbstractValidator<DeleteProgrammingLanguageTechnologyCommand>
{
    public DeleteProgrammingLanguageTechnologyCommandValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageTechnologyMessages.IdIsRequired);
        
        RuleFor(d => d.Id)
            .GreaterThan(0)
            .WithMessage(ProgrammingLanguageTechnologyMessages.GreaterThanZero);
    }
}