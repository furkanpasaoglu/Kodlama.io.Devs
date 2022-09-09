using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;

/// <summary>
/// Programlama dili GetById için validasyon sınıfı
/// </summary>
public class GetByIdProgrammingLanguageQueryValidator : AbstractValidator<GetByIdProgrammingLanguageQuery>
{
    public GetByIdProgrammingLanguageQueryValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageIdIsRequired);
        
        RuleFor(p=>p.Id)
            .GreaterThan(0).WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageGreaterThanZero);
    }
}