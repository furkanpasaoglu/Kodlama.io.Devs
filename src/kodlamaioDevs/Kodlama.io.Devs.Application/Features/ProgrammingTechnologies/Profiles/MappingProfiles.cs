using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Profiles;

/// <summary>
/// Programlama teknolojisi varlığı için AutoMapper profili.
/// </summary>
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProgrammingTechnology, CreatedProgrammingTechnologyDto>().ReverseMap();
        CreateMap<ProgrammingTechnology, CreateProgrammingTechnologyCommand>().ReverseMap();
        
        CreateMap<ProgrammingTechnology, DeleteProgrammingTechnologyCommand>().ReverseMap();
        CreateMap<ProgrammingTechnology, DeletedProgrammingTechnologyDto>().ReverseMap();

        CreateMap<ProgrammingTechnology, UpdateProgrammingTechnologyCommand>().ReverseMap();
        CreateMap<ProgrammingTechnology, UpdatedProgrammingTechnologyDto>().ReverseMap();
        
        CreateMap<IPaginate<ProgrammingTechnology>, ProgrammingTechnologyListModel>().ReverseMap();
        CreateMap<ProgrammingTechnology, ProgrammingTechnologyListDto>().ReverseMap();
        
        CreateMap<ProgrammingTechnology, ProgrammingTechnologyGetByIdDto>().ReverseMap();
        
        CreateMap<ProgrammingTechnology, ProgrammingTechnologyListDto>()
            .ForMember(c=>c.ProgrammingLanguageName, 
                opt=>opt.MapFrom(c=>c.ProgrammingLanguage.Name))
            .ReverseMap();

        CreateMap<IPaginate<ProgrammingTechnology>, ProgrammingTechnologyListModel>().ReverseMap();
    }
}