using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;

/// <summary>
/// Programlama teknolojisi silme komutu
/// </summary>
public class DeleteProgrammingTechnologyCommand : IRequest<DeletedProgrammingTechnologyDto>
{
    public int Id { get; set; }

    /// <summary>
    /// Programlama Teknolojisi Silmek için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class DeleteProgrammingTechnologyCommandHandler : IRequestHandler<DeleteProgrammingTechnologyCommand,DeletedProgrammingTechnologyDto>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

        public DeleteProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
            _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
        }

        public async Task<DeletedProgrammingTechnologyDto> Handle(DeleteProgrammingTechnologyCommand request, CancellationToken cancellationToken)
        {
            var programmingTechnology = await  _programmingTechnologyRepository.GetAsync(x=> x.Id == request.Id);

            _programmingTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingTechnology);
            
            var deletedProgrammingTechnology = await _programmingTechnologyRepository.DeleteAsync(programmingTechnology);
            var mappedProgrammingTechnologyDto = _mapper.Map<DeletedProgrammingTechnologyDto>(deletedProgrammingTechnology);
            return mappedProgrammingTechnologyDto;
        }
    }
}