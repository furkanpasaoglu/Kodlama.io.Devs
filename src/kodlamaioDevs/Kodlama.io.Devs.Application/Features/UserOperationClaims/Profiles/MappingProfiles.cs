using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Profiles;

/// <summary>
/// Kullanıcı Operasyon claim varlığı için AutoMapper profili.
/// </summary>
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        
        CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();

        CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();
        
        CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
        CreateMap<UserOperationClaim, UserOperationClaimListDto>().ReverseMap();
        
        CreateMap<UserOperationClaim, UserOperationClaimGetByIdDto>()
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
                    opt.MapFrom(c => c.User.Email))
            .ForMember(c =>
                    c.OperationClaimName,
                opt =>
                    opt.MapFrom(c => c.OperationClaim.Name))
            .ReverseMap();

        CreateMap<UserOperationClaim, UserOperationClaimListDto>()
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
                    opt.MapFrom(c => c.User.Email))
            .ForMember(c =>
                    c.OperationClaimName,
                opt =>
                    opt.MapFrom(c => c.OperationClaim.Name))
            .ReverseMap();
            

        CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
    }
}