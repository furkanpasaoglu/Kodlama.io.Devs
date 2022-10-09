using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Profiles;

/// <summary>
/// Operasyon claim varlığı için AutoMapper profili.
/// </summary>
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
        
        CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();

        CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
        
        CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
        CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
        CreateMap<OperationClaim, OperationClaimGetByIdDto>().ReverseMap();
    }
}