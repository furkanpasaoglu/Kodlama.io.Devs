namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Dtos;

/// <summary>
/// Silinecek Kullanıcının Sosyal Medya Adreslerini döndüren dto sınıfı.
/// </summary>
public class DeletedUserSocialMediaAddressDto
{
    public int Id { get; set; }
    public string GithubUrl { get; set; }
}