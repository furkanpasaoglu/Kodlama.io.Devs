using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;

/// <summary>
/// Programlama Teknolojisi İçin Validasyon Kuralları
/// </summary>
public class CreateProgrammingTechnologyValidator : AbstractValidator<CreateProgrammingTechnologyCommand>
{
    public CreateProgrammingTechnologyValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingTechnologyConstants.NameIsRequired);
        
        RuleFor(p => p.ProgrammingLanguageId)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingTechnologyConstants.ProgrammingLanguageIdIsRequired);
        
        RuleFor(d => d.ProgrammingLanguageId)
            .GreaterThan(0)
            .WithMessage(ProgrammingTechnologyConstants.ProgrammingLanguageIdGreaterThanZero);
    }
}