using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;

/// <summary>
/// Programlama dili GetById için validasyon sınıfı
/// </summary>
public class GetByIdProgrammingLanguageValidator : AbstractValidator<GetByIdProgrammingLanguageQuery>
{
    public GetByIdProgrammingLanguageValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(ProgrammingLanguageConstants.ProgrammingLanguageIdIsRequired);
        
        RuleFor(p=>p.Id)
            .GreaterThan(0).WithMessage(ProgrammingLanguageConstants.ProgrammingLanguageGreaterThanZero);
    }
}