using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories;

/// <summary>
/// Kullanıcı sosyal medya adresi için kullanılan repository imzasıdır.
/// </summary>
public interface IUserSocialMediaAddressRepository : IAsyncRepository<UserSocialMediaAddress>, IRepository<UserSocialMediaAddress>
{
}