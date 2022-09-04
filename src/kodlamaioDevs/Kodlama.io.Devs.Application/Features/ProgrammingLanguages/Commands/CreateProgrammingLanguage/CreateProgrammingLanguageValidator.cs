using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

/// <summary>
/// Programlama dili oluşturma komutu için validasyon sınıfıdır.
/// </summary>
public class CreateProgrammingLanguageValidator : AbstractValidator<CreateProgrammingLanguageCommand>
{
    public CreateProgrammingLanguageValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageConstants.ProgrammingLanguageNameIsRequired);
    }
}