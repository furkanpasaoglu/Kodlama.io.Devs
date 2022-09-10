using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Rules;

/// <summary>
/// Kullanıcı Sosyal Medya Adresleri için kuralların tanımlandığı sınıf
/// </summary>
public class UserSocialMediaAddressBusinessRules
{
    private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
    private readonly IUserRepository _userRepository;

    public UserSocialMediaAddressBusinessRules(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IUserRepository userRepository)
    {
        _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Github adresi zaten kayıtlı ise hata döndürür
    /// </summary>
    /// <param name="requestGithubUrl">Github adresi</param>
    /// <exception cref="BusinessException">Github adresi zaten sistemde mevcut</exception>
    public async Task UserSocialMediaAddressGithubUrlCanNotBeDuplicated(string requestGithubUrl)
    {
        var userSocialMediaAddress = await _userSocialMediaAddressRepository.GetAsync(x => x.GithubUrl == requestGithubUrl);

        if (userSocialMediaAddress != null)
            throw new BusinessException(UserSocialMediaAddressMessages.GithubUrlCanNotBeDuplicated);
    }

    /// <summary>
    /// Sistemde kayıtlı kullanıcı olup olmadığını kontrol eder
    /// </summary>
    /// <param name="requestUserId">Kullanıcı Id</param>
    /// <exception cref="BusinessException">Kullanıcı sistemde kayıtlı değil</exception>
    public async Task UserMustBeExist(int requestUserId)
    {
        var user = await _userRepository.GetAsync(x => x.Id == requestUserId);

        if (user is null)
            throw new BusinessException(UserSocialMediaAddressMessages.UserNotFound);
    }

    /// <summary>
    /// Sistemde kayıtlı kullanıcı sosyal medya adresi olup olmadığını kontrol eder
    /// </summary>
    /// <param name="userSocialMediaAddress">Kullanıcı sosyal medya adresi varlığı</param>
    /// <exception cref="BusinessException">Kullanıcı sosyal medya adresi sistemde kayıtlı değil</exception>
    public void SocialMediaAddressShouldExistWhenRequested(UserSocialMediaAddress? userSocialMediaAddress)
    {
        if (userSocialMediaAddress is null)
            throw new BusinessException(UserSocialMediaAddressMessages.UserSocialMediaAddressIsNotFound);
    }

    /// <summary>
    /// Bir den fazla sosyal medya github adresi eklenemez
    /// </summary>
    /// <param name="requestUserId">Kullanıcı Id</param>
    /// <exception cref="BusinessException">Kullanıcıya ait bir den fazla github adresi eklenemez</exception>
    public async Task UserSocialMediaAddressCanNotHaveMoreThanOneGithubAddress(int requestUserId)
    {
        var userSocialMediaAddress = await _userSocialMediaAddressRepository.GetListAsync(x => x.UserId == requestUserId);
        var socialMediaAddressCount = userSocialMediaAddress.Items.Select(x => x.GithubUrl).Count();
        if (socialMediaAddressCount > 1)
            throw new BusinessException(UserSocialMediaAddressMessages.CanNotAddMultipleGithubAddresses);
    }
}