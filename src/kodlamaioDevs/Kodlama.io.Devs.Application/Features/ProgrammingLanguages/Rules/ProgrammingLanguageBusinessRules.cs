using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;

/// <summary>
/// Programlama Dili İçin Kurallar
/// </summary>
public class ProgrammingLanguageBusinessRules
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    /// <summary>
    /// Programlama Dili Varlığının Adı Tekrar Edemez
    /// </summary>
    /// <param name="name"> Programlama Dili Adı </param>
    /// <exception cref="BusinessException"> Programlama Dili Adı Tekrar Edemez </exception>
    public async Task ProgrammingLanguageNameCanNotBeDuplicated(string name)
    {
        var result = await _programmingLanguageRepository.GetListAsync(x=>x.Name == name);
        if (result.Items.Any())
            throw new BusinessException( ProgrammingLanguageMessages.ProgrammingLanguageNameIsAlreadyExist);
    } 
    
    /// <summary>
    /// Programlama Dili Varlığını Kimliğe Göre Kontrol Et
    /// </summary>
    /// <param name="id"> Programlama Dili Kimliği </param>
    /// <exception cref="BusinessException"> Programlama Dili Bu Kimliğe Ait Varlık Bulunamadı </exception> 
    public async Task ProgrammingLanguageIdShouldBeExist(int id)
    {
        var result = await _programmingLanguageRepository.GetListAsync(x=>x.Id == id);
        if (!result.Items.Any())
            throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageNotFound);
    }
    
    /// <summary>
    /// Bu Programlama Dili Varlığının Boş Olup Olmadığını Kontrol Et
    /// </summary>
    /// <param name="programmingLanguage"> Programlama Dili Varlığı </param>
    /// <exception cref="BusinessException"> Programlama Dili Varlığı Boş Olamaz </exception>
    public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
    {
        if (programmingLanguage is null) 
            throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageDoesNotHaveAnyRecords);
    }
}