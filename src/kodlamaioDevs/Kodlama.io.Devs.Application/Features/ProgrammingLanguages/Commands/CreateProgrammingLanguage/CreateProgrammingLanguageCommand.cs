﻿using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

/// <summary>
/// Programlama Dili eklemek için kullanılan komut sınıfıdır.
/// </summary>
public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
{
    public string Name { get; set; }
    
    /// <summary>
    /// Programlama Dili Eklemek için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class CreateProgrammingLanguageHandler : IRequestHandler<CreateProgrammingLanguageCommand,CreatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public CreateProgrammingLanguageHandler(IProgrammingLanguageRepository programmingLanguageRepository,IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
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