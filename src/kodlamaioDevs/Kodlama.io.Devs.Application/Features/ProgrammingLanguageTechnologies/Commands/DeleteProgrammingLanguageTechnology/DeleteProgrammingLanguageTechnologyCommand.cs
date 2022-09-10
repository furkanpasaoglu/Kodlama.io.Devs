using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology;

/// <summary>
/// Programlama dili teknolojisi silme komutu
/// </summary>
public class DeleteProgrammingLanguageTechnologyCommand : IRequest<DeletedProgrammingLanguageTechnologyDto>
{
    public int Id { get; set; }

    /// <summary>
    /// Programlama Dili Teknolojisi Silmek için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<DeleteProgrammingLanguageTechnologyCommand,DeletedProgrammingLanguageTechnologyDto>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageLanguageTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

        public DeleteProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageLanguageTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
        {
            _programmingLanguageLanguageTechnologyRepository = programmingLanguageLanguageTechnologyRepository;
            _mapper = mapper;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
        }

        public async Task<DeletedProgrammingLanguageTechnologyDto> Handle(DeleteProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            var programmingLanguageTechnology = await  _programmingLanguageLanguageTechnologyRepository.GetAsync(x=> x.Id == request.Id);

            _programmingLanguageTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingLanguageTechnology);
            
            var deletedProgrammingLanguageTechnology = await _programmingLanguageLanguageTechnologyRepository.DeleteAsync(programmingLanguageTechnology);
            var mappedProgrammingLanguageTechnologyDto = _mapper.Map<DeletedProgrammingLanguageTechnologyDto>(deletedProgrammingLanguageTechnology);
            return mappedProgrammingLanguageTechnologyDto;
        }
    }
}