using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

/// <summary>
/// Programlama dili silme komutu için validasyon sınıfıdır.
/// </summary>
public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
{
    public DeleteProgrammingLanguageCommandValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageIdIsRequired);
        
        RuleFor(d => d.Id)
            .GreaterThan(0)
            .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageGreaterThanZero);
    }
}