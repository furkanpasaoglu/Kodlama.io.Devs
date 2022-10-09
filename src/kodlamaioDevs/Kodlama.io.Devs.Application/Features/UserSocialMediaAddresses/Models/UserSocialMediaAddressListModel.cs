using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Dtos;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Models;

/// <summary>
/// Kullanıcı Sosyal Medya Adresi için kullanılan model
/// </summary>
public class UserSocialMediaAddressListModel : BasePageableModel
{
    public IList<UserSocialMediaAddressListDto> Items { get; set; }
}