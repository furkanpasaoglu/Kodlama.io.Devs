namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Dtos;

/// <summary>
/// Tüm Kullanıcıların Sosyal Medya Adreslerini döndüren dto sınıfı.
/// </summary>
public class UserSocialMediaAddressListDto
{
    public int Id { get; set; }
    public string GithubUrl { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}