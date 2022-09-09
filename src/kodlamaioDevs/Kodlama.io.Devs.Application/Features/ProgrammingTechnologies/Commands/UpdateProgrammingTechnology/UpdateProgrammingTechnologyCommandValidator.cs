using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;

/// <summary>
/// Programlama teknolojisi güncelleme komutu için validasyon sınıfıdır.
/// </summary>
public class UpdateProgrammingTechnologyCommandValidator: AbstractValidator<UpdateProgrammingTechnologyCommand>
{
    public UpdateProgrammingTechnologyCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingTechnologyMessages.IdIsRequired);
        
        RuleFor(x => x.Name)
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