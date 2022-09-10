using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Domain.Entities;

//Kullanıcının Sosyal Medyası için oluşturduğumuz temel sınıfımız.
public class UserSocialMediaAddress : Entity
{
    public int UserId { get; set; }
    public string GithubUrl { get; set; }

    public virtual User? User { get; set; }

    public UserSocialMediaAddress()
    {
        
    }

    public UserSocialMediaAddress(int id, int userId, string githubUrl) : this()
    {
        Id = id;
        UserId = userId;
        GithubUrl = githubUrl;
    }
}