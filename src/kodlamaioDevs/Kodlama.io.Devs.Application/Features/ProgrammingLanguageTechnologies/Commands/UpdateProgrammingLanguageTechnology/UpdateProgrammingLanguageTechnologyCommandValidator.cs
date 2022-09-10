using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;

/// <summary>
/// Programlama dili teknolojisi güncelleme komutu için validasyon sınıfıdır.
/// </summary>
public class UpdateProgrammingLanguageTechnologyCommandValidator: AbstractValidator<UpdateProgrammingLanguageTechnologyCommand>
{
    public UpdateProgrammingLanguageTechnologyCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageTechnologyMessages.IdIsRequired);
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageTechnologyMessages.NameIsRequired);
        
        RuleFor(p => p.ProgrammingLanguageId)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageTechnologyMessages.ProgrammingLanguageIdIsRequired);
        
        RuleFor(d => d.ProgrammingLanguageId)
            .GreaterThan(0)
            .WithMessage(ProgrammingLanguageTechnologyMessages.ProgrammingLanguageIdGreaterThanZero);
    }
}