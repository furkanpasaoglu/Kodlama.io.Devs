using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories;

/// <summary>
/// Kullanıclar için metotların imzalarını tutar.
/// </summary>
public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
    
}