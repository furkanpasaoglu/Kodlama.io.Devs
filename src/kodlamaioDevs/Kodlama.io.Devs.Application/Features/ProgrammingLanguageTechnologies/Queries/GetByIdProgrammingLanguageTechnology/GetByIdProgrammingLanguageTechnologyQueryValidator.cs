using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology;

/// <summary>
/// Programlama dili teknolojisi get by id komutu için validasyon sınıfıdır.
/// </summary>
public class GetByIdProgrammingLanguageTechnologyQueryValidator : AbstractValidator<GetByIdProgrammingLanguageTechnologyQuery>
{
    public GetByIdProgrammingLanguageTechnologyQueryValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingLanguageTechnologyMessages.IdIsRequired);
        
        RuleFor(p=>p.Id)
            .GreaterThan(0).WithMessage(ProgrammingLanguageTechnologyMessages.GreaterThanZero);
    }
}