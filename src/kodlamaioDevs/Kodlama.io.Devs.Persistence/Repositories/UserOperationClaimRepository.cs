using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories;

/// <summary>
/// Kullanıcı için işlem yetkilerini yöneten metotlarını tanımlar.
/// </summary>
public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim,BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}