using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;

/// <summary>
/// Programlama teknolojileri için kuralların tanımlandığı sınıf
/// </summary>
public class ProgrammingTechnologyBusinessRules
{
    private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository programmingTechnologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingTechnologyRepository = programmingTechnologyRepository;
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    /// <summary>
    /// Programlama dili olup olmadığını kontrol eder
    /// </summary>
    /// <param name="programmingLanguageId">Programlama dili id</param>
    /// <exception cref="BusinessException">Programlama dili bulunamadı</exception>
    public async Task ProgrammingLanguageMustExistAsync(int programmingLanguageId)
    {
        var programmingLanguage = await _programmingLanguageRepository.GetAsync(x=>x.Id == programmingLanguageId);
        if (programmingLanguage is null)
            throw new BusinessException(ProgrammingTechnologyConstants.ProgrammingLanguageNotFound);
    }

    /// <summary>
    /// Programlama teknolojisi adı varsa tekrar edemez
    /// </summary>
    /// <param name="name">Programlama teknolojisi adı</param>
    /// <exception cref="BusinessException">Programlama Teknolojisi Adı Tekrar Edemez</exception>
    public async Task ProgrammingTechnologyNameCanNotBeDuplicated(string name)
    {
        var result = await _programmingTechnologyRepository.GetListAsync(x=>x.Name == name);
        if (result.Items.Any())
            throw new BusinessException(ProgrammingTechnologyConstants.NameIsAlreadyExist);
    } 
    
    /// <summary>
    /// Bu Programlama Teknoloji Varlığının Boş Olup Olmadığını Kontrol Et
    /// </summary>
    /// <param name="programmingTechnology"> Programlama Teknoloji Varlığı </param>
    /// <exception cref="BusinessException"> Programlama Teknoloji Varlığı Boş Olamaz </exception>
    public void ProgrammingTechnologyShouldExistWhenRequested(ProgrammingTechnology programmingTechnology)
    {
        if (programmingTechnology is null) 
            throw new BusinessException(ProgrammingTechnologyConstants.DoesNotHaveAnyRecords);
    }
}