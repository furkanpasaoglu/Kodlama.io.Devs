using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories;

/// <summary>
/// Kullanıcı sosyal medya adresi için kullanılan repository metotları.
/// </summary>
public class UserSocialMediaAddressRepository : EfRepositoryBase<UserSocialMediaAddress,BaseDbContext>, IUserSocialMediaAddressRepository
{
    public UserSocialMediaAddressRepository(BaseDbContext context) : base(context)
    {
    }
}