using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

/// <summary>
/// Programlama dili oluşturma komutu için validasyon sınıfıdır.
/// </summary>
public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
{
    public CreateProgrammingLanguageCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageNameIsRequired);
    }
}