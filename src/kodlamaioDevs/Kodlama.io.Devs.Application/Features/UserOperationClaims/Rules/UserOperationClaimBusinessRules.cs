using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;

/// <summary>
/// Kullanıcı Operasyon claim'lerinin kurallarını tutar.
/// </summary>
public class UserOperationClaimBusinessRules
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IUserRepository _userRepository;
    private readonly IOperationClaimRepository _operationClaimRepository;

    public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _userRepository = userRepository;
        _operationClaimRepository = operationClaimRepository;
    }
    
    /// <summary>
    /// Operasyon claim id ve User Id zaten varsa hata döner.
    /// </summary>
    /// <param name="userId"> Kullanıcı Id </param>
    /// <param name="operationClaimId"> Operasyon claim Id </param>
    /// <exception cref="BusinessException"> Operasyon claim id ve User Id zaten varsa hata döner. </exception>
    public async Task UserIdAndOperationClaimIdCanNotBeDuplicatedWhenRequested(int userId,int operationClaimId)
    {
        var operationClaim = await _userOperationClaimRepository.GetAsync(x => x.UserId == userId && x.OperationClaimId == operationClaimId);
        if (operationClaim != null)
            throw new BusinessException(UserOperationClaimMessages.UserIdAndOperationClaimIdCanNotBeDuplicated);
    }
    
    /// <summary>
    /// Kullanıcı Operasyon claim Varlığını Kimliğe Göre Kontrol Et
    /// </summary>
    /// <param name="id"> Kullanıcı Operasyon claim Kimliği </param>
    /// <exception cref="BusinessException"> Kullanıcı Operasyon claim Bu Kimliğe Ait Varlık Bulunamadı </exception> 
    public async Task UserOperationClaimIdShouldBeExist(int id)
    {
        var result = await _userOperationClaimRepository.GetListAsync(x=>x.Id == id);
        if (!result.Items.Any())
            throw new BusinessException(UserOperationClaimMessages.IdShouldBeExist);
    }
    
    /// <summary>
    /// Bu Kullanıcı Operasyon claim Varlığının Boş Olup Olmadığını Kontrol Et
    /// </summary>
    /// <param name="userOperationClaim"> Kullanıcı Operasyon Claim Varlığı </param>
    /// <exception cref="BusinessException"> Kullanıcı Operasyon Claim Varlığı Boş Olamaz </exception>
    public void OperationClaimShouldExistWhenRequested(UserOperationClaim userOperationClaim)
    {
        if (userOperationClaim is null) 
            throw new BusinessException(UserOperationClaimMessages.DoesNotHaveAnyRecords);
    }

    /// <summary>
    /// Kullanıcı varmı diye kontrol eder
    /// </summary>
    /// <param name="userId"> Kullanıcı Id </param>
    /// <exception cref="BusinessException"> Kullanıcı Bulunamadı </exception>
    public async Task CheckIfUserExists(int userId)
    {
        var user = await _userRepository.GetAsync(x => x.Id == userId);
        if(user is null)
            throw new BusinessException(UserOperationClaimMessages.UserDoesNotExists);
    }
    
    /// <summary>
    /// Operasyon Claim varmı diye kontrol eder
    /// </summary>
    /// <param name="operationClaimId"> Operasyon Claim Id </param>
    /// <exception cref="BusinessException"> Operasyon Claim Bulunamadı </exception>
    public async Task CheckIfOperationClaimExists(int operationClaimId)
    {
        var user = await _operationClaimRepository.GetAsync(x => x.Id == operationClaimId);
        if(user is null)
            throw new BusinessException(UserOperationClaimMessages.OperationClaimDoesNotExists);
    }
    
}