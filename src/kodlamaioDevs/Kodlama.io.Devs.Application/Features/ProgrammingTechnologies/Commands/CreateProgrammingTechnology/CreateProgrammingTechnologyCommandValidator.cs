using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;

/// <summary>
/// Programlama Teknolojisi İçin Validasyon Kuralları
/// </summary>
public class CreateProgrammingTechnologyCommandValidator : AbstractValidator<CreateProgrammingTechnologyCommand>
{
    public CreateProgrammingTechnologyCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingTechnologyMessages.NameIsRequired);
        
        RuleFor(p => p.ProgrammingLanguageId)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingTechnologyMessages.ProgrammingLanguageIdIsRequired);
        
        RuleFor(d => d.ProgrammingLanguageId)
            .GreaterThan(0)
            .WithMessage(ProgrammingTechnologyMessages.ProgrammingLanguageIdGreaterThanZero);
    }
}