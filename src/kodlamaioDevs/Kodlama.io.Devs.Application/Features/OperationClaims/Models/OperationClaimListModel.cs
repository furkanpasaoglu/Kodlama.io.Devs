using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Models;

/// <summary>
/// Operasyon Claim için geriye dönen sayfalanmış veri modeli
/// </summary>
public class OperationClaimListModel : BasePageableModel
{
    public IList<OperationClaimListDto> Items { get; set; }
}