using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories;

/// <summary>
/// Kullanıcılar için metotların bulunduğu repository sınıfıdır.
/// </summary>
public class UserRepository : EfRepositoryBase<User,BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {
    }
}