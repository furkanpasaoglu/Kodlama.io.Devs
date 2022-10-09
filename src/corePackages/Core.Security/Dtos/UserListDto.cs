using Core.Security.Enums;

namespace Core.Security.Dtos;

/// <summary>
/// Kullanıcı için Dto
/// </summary>
public class UserListDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }
}