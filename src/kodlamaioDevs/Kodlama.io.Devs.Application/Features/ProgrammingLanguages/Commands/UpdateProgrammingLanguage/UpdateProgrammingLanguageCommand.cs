﻿using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

/// <summary>
/// Programlama Dili güncellemek için kullanılan komut sınıfıdır.
/// </summary>
public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>,ISecuredRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string[] Roles { get; } =
    {
        ProgrammingLanguageRoles.ProgrammingLanguageAdmin,
        ProgrammingLanguageRoles.ProgrammingLanguageUpdate
    };

    /// <summary>
    /// Programlama Dili Güncellemek için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand,UpdatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await _programmingLanguageBusinessRules.ProgrammingLanguageIdShouldBeExist(request.Id);
            await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicated(request.Name);
            
            var programmingLanguage = await _programmingLanguageRepository.GetAsync(x=>x.Id == request.Id);
            
            var mappedProgrammingLanguage = _mapper.Map(request,programmingLanguage);
            var updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedProgrammingLanguage);
            var mappedUpdatedProgrammingLanguage = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);
            return mappedUpdatedProgrammingLanguage;
        }
    }
}