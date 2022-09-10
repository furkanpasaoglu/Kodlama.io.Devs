using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.DeleteUserSocialMediaAddress;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Dtos;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Profiles;

/// <summary>
/// Kullanıcı Sosyal Medya Adres varlığı için AutoMapper profili.
/// </summary>
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserSocialMediaAddress, CreatedUserSocialMediaAddressDto>().ReverseMap();
        CreateMap<UserSocialMediaAddress, CreateUserSocialMediaAddressCommand>().ReverseMap();
        
        CreateMap<UserSocialMediaAddress, DeleteUserSocialMediaAddressCommand>().ReverseMap();
        CreateMap<UserSocialMediaAddress, DeletedUserSocialMediaAddressDto>().ReverseMap();

        CreateMap<UserSocialMediaAddress, UpdateUserSocialMediaAddressCommand>().ReverseMap();
        CreateMap<UserSocialMediaAddress, UpdatedUserSocialMediaAddressDto>().ReverseMap();
        
        CreateMap<IPaginate<UserSocialMediaAddress>, UserSocialMediaAddressListModel>().ReverseMap();
        CreateMap<UserSocialMediaAddress, UserSocialMediaAddressListDto>().ReverseMap();
        
        CreateMap<UserSocialMediaAddress, UserSocialMediaAddressGetByIdDto>()
            .ForMember(c =>
                    c.FirstName,
                opt =>
                    opt.MapFrom(c => c.User.FirstName))
            .ForMember(c =>
                    c.LastName,
                opt =>
                    opt.MapFrom(c => c.User.LastName))
            .ForMember(c =>
                    c.Email,
                opt =>
                    opt.MapFrom(c => c.User.Email)).ReverseMap();

        CreateMap<UserSocialMediaAddress, UserSocialMediaAddressListDto>()
            .ForMember(c =>
                    c.FirstName,
                opt =>
                    opt.MapFrom(c => c.User.FirstName))
            .ForMember(c =>
                    c.LastName,
                opt =>
                    opt.MapFrom(c => c.User.LastName))
            .ForMember(c =>
                    c.Email,
                opt =>
                    opt.MapFrom(c => c.User.Email)).ReverseMap();
            

        CreateMap<IPaginate<UserSocialMediaAddress>, ProgrammingLanguageTechnologyListModel>().ReverseMap();
    }
}