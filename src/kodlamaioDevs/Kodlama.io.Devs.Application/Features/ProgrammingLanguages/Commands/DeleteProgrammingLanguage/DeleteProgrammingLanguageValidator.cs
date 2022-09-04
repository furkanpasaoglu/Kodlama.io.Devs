using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

/// <summary>
/// Programlama dili silme komutu için validasyon sınıfıdır.
/// </summary>
public class DeleteProgrammingLanguageValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
{
    public DeleteProgrammingLanguageValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageConstants.ProgrammingLanguageIdIsRequired);
        
        RuleFor(d => d.Id)
            .GreaterThan(0)
            .WithMessage(ProgrammingLanguageConstants.ProgrammingLanguageGreaterThanZero);
    }
}