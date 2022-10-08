using Core.Security.Entities;
using Core.Security.JWT;

namespace Kodlama.io.Devs.Application.Services.AuthService;

/// <summary>
/// Kullanıcı giriş işlemleri için kullanılar servis imzası
/// </summary>
public interface IAuthService
{
    Task<AccessToken> CreateAccessToken(User user);
    Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
    Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
}