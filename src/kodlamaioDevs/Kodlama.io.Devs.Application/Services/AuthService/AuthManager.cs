using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Services.AuthService;

/// <summary>
/// Kullanıcı giriş işlemleri için kullanılan servis
/// </summary>
public class AuthManager : IAuthService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _tokenHelper = tokenHelper;
        _refreshTokenRepository = refreshTokenRepository;
    }

    /// <summary>
    /// Yenilenmiş Tokeni veritabanına kaydeder
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns> Yenilenmiş Token </returns>
    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }
    
    /// <summary>
    /// Kullanıcı için Token oluşturur
    /// </summary>
    /// <param name="user">Kullanıcı</param>
    /// <returns> Token bilgileri</returns>
    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IPaginate<UserOperationClaim> userOperationClaims =
            await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                include: u => u.Include(u => u.OperationClaim));

        IList<OperationClaim> operationClaims = userOperationClaims.Items
            .Select(u => new OperationClaim { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();
        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    /// <summary>
    /// Yenilenmiş Token Oluşturur
    /// </summary>
    /// <param name="user"> Kullanıcı </param>
    /// <param name="ipAddress"> Kullanıcının IP adresi </param>
    /// <returns> Yenilenmiş Token </returns>
    public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return await Task.FromResult(refreshToken);
    }
}