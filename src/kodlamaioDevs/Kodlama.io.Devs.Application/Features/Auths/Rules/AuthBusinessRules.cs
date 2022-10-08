using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Auths.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.Auths.Rules;

/// <summary>
/// Kimlik doğrulama işlemleri için kuralların tanımlandığı sınıftır.
/// </summary>
public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    /// <summary>
    /// E-Poçta adresi sistemde kayıtlı mı?
    /// </summary>
    /// <param name="email"> E-Poçta adresi </param>
    /// <exception cref="BusinessException"> E-Poçta adresi sistemde kayıtlı ise </exception>
    public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
    {
        var user = await _userRepository.GetAsync(x=>x.Email == email);
        if (user is not null)
            throw new BusinessException(AuthMessages.EmailCanNotBeDuplicatedWhenRegistered);
    }
    
    /// <summary>
    /// Kullanıcı giriş yaparken sistemde kayıtlı mı?
    /// </summary>
    /// <param name="email"></param>
    /// <exception cref="BusinessException"></exception>
    public async Task UserShouldBeExistWhenLogin(string email)
    {
        var user = await _userRepository.GetAsync(x=>x.Email == email);
        if (user is null)
            throw new BusinessException(AuthMessages.UserIsNotFound);
    }
    
    /// <summary>
    /// Kullanıcı'nın şifresi doğru mu?
    /// </summary>
    /// <param name="requestPassword">Kullanıcı'nın girdiği şifre</param>
    /// <param name="userPasswordHash">Kullanıcı'nın hashlenmiş şifresi</param>
    /// <param name="userPasswordSalt">Kullanıcı'nın şifresinin salt değeri</param>
    /// <exception cref="BusinessException">Kullanıcı'nın şifresi yanlış</exception>
    public void CheckIfPasswordIsCorrect(string requestPassword, byte[] userPasswordHash, byte[] userPasswordSalt)
    {
        if (!HashingHelper.VerifyPasswordHash(requestPassword, userPasswordHash, userPasswordSalt))
            throw new BusinessException(AuthMessages.CheckIfPasswordIsCorrect);
    }
}