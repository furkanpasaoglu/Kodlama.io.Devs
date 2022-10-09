namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;

/// <summary>
/// Kullanıcı Operasyon claim güncelleme dto
/// </summary>
public class UpdatedUserOperationClaimDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}