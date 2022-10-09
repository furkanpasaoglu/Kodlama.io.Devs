using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

/// <summary>
/// Programlama dili güncelleme komutu için validasyon sınıfıdır.
/// </summary>
public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
{
    public UpdateProgrammingLanguageCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageIdIsRequired);
        
        RuleFor(d => d.Id)
            .GreaterThan(0)
            .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageGreaterThanZero);
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageNameIsRequired);
    }
}