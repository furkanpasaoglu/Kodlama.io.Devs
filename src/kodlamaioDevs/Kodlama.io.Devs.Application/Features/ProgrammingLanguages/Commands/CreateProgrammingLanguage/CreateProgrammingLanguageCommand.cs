using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

/// <summary>
/// Programlama Dili eklemek için kullanılan komut sınıfıdır.
/// </summary>
public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>, ISecuredRequest
{
    public string Name { get; set; }
    public string[] Roles { get; } = { "User" };

    /// <summary>
    /// Programlama Dili Eklemek için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand,CreatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository,IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicated(request.Name);
            
            var mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
            var createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguage);
            var mappedCreatedProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage);
            return mappedCreatedProgrammingLanguageDto;
        }
    }
}