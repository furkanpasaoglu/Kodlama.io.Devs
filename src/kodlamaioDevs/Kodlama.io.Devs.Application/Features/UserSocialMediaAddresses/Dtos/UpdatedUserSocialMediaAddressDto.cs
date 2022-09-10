namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Dtos;

/// <summary>
/// Güncellenecek Kullanıcının Sosyal Medya Adreslerini döndüren dto sınıfı.
/// </summary>
public class UpdatedUserSocialMediaAddressDto
{
    public int Id { get; set; }
    public string GithubUrl { get; set; }
}