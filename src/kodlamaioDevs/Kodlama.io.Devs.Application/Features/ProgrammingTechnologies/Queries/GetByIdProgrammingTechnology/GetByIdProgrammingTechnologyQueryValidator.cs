using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetByIdProgrammingTechnology;

/// <summary>
/// Programlama dili get by id komutu için validasyon sınıfıdır.
/// </summary>
public class GetByIdProgrammingTechnologyQueryValidator : AbstractValidator<GetByIdProgrammingTechnologyQuery>
{
    public GetByIdProgrammingTechnologyQueryValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(ProgrammingTechnologyConstants.IdIsRequired);
        
        RuleFor(p=>p.Id)
            .GreaterThan(0).WithMessage(ProgrammingTechnologyConstants.ProgrammingTechnologyGreaterThanZero);
    }
}