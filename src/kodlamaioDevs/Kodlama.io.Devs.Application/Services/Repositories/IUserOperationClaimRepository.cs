using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories;

/// <summary>
/// Kullanıcı için işlem yetkilerini yöneten metotların imzasını tanımlar.
/// </summary>
public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
{
    
}