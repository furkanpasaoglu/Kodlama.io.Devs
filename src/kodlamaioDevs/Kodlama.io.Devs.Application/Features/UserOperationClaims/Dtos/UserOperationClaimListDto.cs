namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;

/// <summary>
/// Getirilecek Tüm Kullanıcı Operasyon Claim'ini döndüren dto sınıfı.
/// </summary>
public class UserOperationClaimListDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string OperationClaimName { get; set; }
}