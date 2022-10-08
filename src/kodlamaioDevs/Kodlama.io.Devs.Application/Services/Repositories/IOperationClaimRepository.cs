using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories;

/// <summary>
/// Operasyonlar için metotların imzasını tanımlar.
/// </summary>
public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
{
    
}