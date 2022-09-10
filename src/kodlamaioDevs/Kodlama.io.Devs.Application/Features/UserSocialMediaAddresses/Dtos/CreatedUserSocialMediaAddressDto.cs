namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Dtos;

/// <summary>
/// Oluşturulacak Kullanıcının Sosyal Medya Adreslerini döndüren dto sınıfı.
/// </summary>
public class CreatedUserSocialMediaAddressDto
{
    public int Id { get; set; }
    public string GithubUrl { get; set; }
}