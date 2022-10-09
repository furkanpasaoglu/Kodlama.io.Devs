
namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;

/// <summary>
/// Kullanıcı Operasyon Claim için geri dönüş modeli
/// </summary>
public class UserOperationClaimGetByIdDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string OperationClaimName { get; set; }
}