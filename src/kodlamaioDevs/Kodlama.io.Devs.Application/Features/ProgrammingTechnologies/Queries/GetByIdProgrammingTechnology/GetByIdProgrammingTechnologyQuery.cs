using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetByIdProgrammingTechnology;

/// <summary>
/// Programlama teknolojisi için sorgu sınıfı
/// </summary>
public class GetByIdProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyGetByIdDto>
{
    public int Id { get; set; }

    /// <summary>
    /// Programlama teknolojisi için işleyici sınıf
    /// </summary>
    public class GetByIdProgrammingTechnologyQueryHandler : IRequestHandler<GetByIdProgrammingTechnologyQuery,ProgrammingTechnologyGetByIdDto>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

        public GetByIdProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
            _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
        }

        public async Task<ProgrammingTechnologyGetByIdDto> Handle(GetByIdProgrammingTechnologyQuery request, CancellationToken cancellationToken)
        {
            var programmingTechnology = await _programmingTechnologyRepository.Query().Include(x=>x.ProgrammingLanguage).FirstOrDefaultAsync(x=> x.Id == request.Id, cancellationToken: cancellationToken);
            
            _programmingTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingTechnology);
            
            var programmingTechnologyGetByIdDto = _mapper.Map<ProgrammingTechnologyGetByIdDto>(programmingTechnology);
            return programmingTechnologyGetByIdDto;
        }
    }
}