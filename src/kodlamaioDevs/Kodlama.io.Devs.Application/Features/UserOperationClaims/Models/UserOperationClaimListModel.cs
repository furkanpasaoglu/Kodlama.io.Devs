using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;

/// <summary>
/// Kullanıcı Operasyon Claim için geriye dönen sayfalanmış veri modeli
/// </summary>
public class UserOperationClaimListModel : BasePageableModel
{
    public IList<UserOperationClaimListDto> Items { get; set; }
}