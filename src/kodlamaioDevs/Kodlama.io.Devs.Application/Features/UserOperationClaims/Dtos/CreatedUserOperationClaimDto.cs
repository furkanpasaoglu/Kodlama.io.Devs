namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;

/// <summary>
/// Kullanıcı Operasyon claim oluşturma dto
/// </summary>
public class CreatedUserOperationClaimDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}