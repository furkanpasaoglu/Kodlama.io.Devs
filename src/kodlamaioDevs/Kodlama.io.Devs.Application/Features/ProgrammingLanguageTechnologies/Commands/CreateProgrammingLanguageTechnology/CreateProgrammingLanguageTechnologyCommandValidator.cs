using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;

/// <summary>
/// Programlama dili Teknolojisi İçin Validasyon Kuralları
/// </summary>
public class CreateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<CreateProgrammingLanguageTechnologyCommand>
{
    public CreateProgrammingLanguageTechnologyCommandValidator()
    {
        RuleFor(p => p.Name)
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