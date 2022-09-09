using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;

/// <summary>
/// Programlama Teknolojisi Oluşturma Komutu
/// </summary>
public class CreateProgrammingTechnologyCommand: IRequest<CreatedProgrammingTechnologyDto>
{
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// Programlama teknolojisi oluşturmak için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class CreateProgrammingTechnologyCommandHandler : IRequestHandler<CreateProgrammingTechnologyCommand,CreatedProgrammingTechnologyDto>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

        public CreateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
            _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
        }

        public async Task<CreatedProgrammingTechnologyDto> Handle(CreateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _programmingTechnologyBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicated(request.Name);
            await _programmingTechnologyBusinessRules.ProgrammingLanguageMustExistAsync(request.ProgrammingLanguageId);
            
            var mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);
            var createdProgrammingTechnology = await _programmingTechnologyRepository.AddAsync(mappedProgrammingTechnology);
            var mappedCreatedProgrammingTechnologyDto = _mapper.Map<CreatedProgrammingTechnologyDto>(createdProgrammingTechnology);
            return mappedCreatedProgrammingTechnologyDto;
        }
    }
}