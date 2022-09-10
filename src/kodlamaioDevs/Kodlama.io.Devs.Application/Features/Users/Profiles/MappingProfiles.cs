using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Users.Commands.LoginUser;
using Kodlama.io.Devs.Application.Features.Users.Commands.RegisterUser;

namespace Kodlama.io.Devs.Application.Features.Users.Profiles;

/// <summary>
/// Kullanıcı varlığı için AutoMapper profili.
/// </summary>
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, LoginUserCommand>().ReverseMap();
        CreateMap<User, RegisterUserCommand>().ReverseMap();
    }
}