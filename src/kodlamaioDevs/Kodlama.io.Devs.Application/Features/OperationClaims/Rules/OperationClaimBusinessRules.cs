using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Rules;

/// <summary>
/// Operasyon claim'lerinin kurallarını tutar.
/// </summary>
public class OperationClaimBusinessRules
{
    private readonly IOperationClaimRepository _operationClaimRepository;

    public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    /// <summary>
    /// Operasyon claim adı zaten varsa hata döner.
    /// </summary>
    /// <param name="name">Operasyon claim adı.</param>
    /// <exception cref="BusinessException">Operasyon claim adı zaten varsa hata döner.</exception>
    public async Task NameCanNotBeDuplicatedWhenRequested(string name)
    {
        var operationClaim = await _operationClaimRepository.GetAsync(x => x.Name == name);
        if (operationClaim != null)
            throw new BusinessException(OperationClaimMessages.NameCanNotBeDuplicated);
    }
    
    /// <summary>
    /// Operasyon claim Varlığını Kimliğe Göre Kontrol Et
    /// </summary>
    /// <param name="id"> Operasyon claim Kimliği </param>
    /// <exception cref="BusinessException"> Operasyon claim Bu Kimliğe Ait Varlık Bulunamadı </exception> 
    public async Task OperationClaimIdShouldBeExist(int id)
    {
        var result = await _operationClaimRepository.GetListAsync(x=>x.Id == id);
        if (!result.Items.Any())
            throw new BusinessException(OperationClaimMessages.IdShouldBeExist);
    }
}