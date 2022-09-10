using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Users.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.Users.Rules;

/// <summary>
/// Kullanıcılar İçin Kurallar
/// </summary>
public class UserBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    
    /// <summary>
    /// Bu Kullanıcı E-posta adresi ile daha önce kayıt olmuş mu?
    /// </summary>
    /// <param name="requestEmail">Kullanıcı E-posta adresi</param>
    /// <exception cref="BusinessException">Kullanıcı daha önce kayıt olmuş</exception>
    public async Task UserEmailAddressCanNotBeDuplicated(string requestEmail)
    {
        var user = await _userRepository.GetAsync(x => x.Email == requestEmail);
        if (user is not null)
            throw new BusinessException(UserMessages.UserEmailAlreadyExists);
    }

    /// <summary>
    /// Kullanıcı Var olup olmadığını kontrol eder
    /// </summary>
    /// <param name="user">Kullanıcı bilgileri </param>
    /// <exception cref="BusinessException">Kullanıcı bulunamadı</exception>
    public void CheckIfUserExists(User user)
    {
        if (user is null)
            throw new BusinessException(UserMessages.UserNotFound);
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
            throw new BusinessException(UserMessages.PasswordIsNotCorrect);
    }
}