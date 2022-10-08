using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Constants;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;

/// <summary>
/// Programlama Dili Teknolojisi Güncelleme Komutu
/// </summary>
public class UpdateProgrammingLanguageTechnologyCommand : IRequest<UpdatedProgrammingLanguageTechnologyDto>,ISecuredRequest
{
    public int Id { get; set; }
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
    public string[] Roles { get; } =
    {
        ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyAdmin,
        ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyUpdate
    };
    
    /// <summary>
    /// Programlama Dili Teknolojisi Güncellemek için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommand,UpdatedProgrammingLanguageTechnologyDto>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageLanguageTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

        public UpdateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageLanguageTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
        {
            _programmingLanguageLanguageTechnologyRepository = programmingLanguageLanguageTechnologyRepository;
            _mapper = mapper;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
        }

        public async Task<UpdatedProgrammingLanguageTechnologyDto> Handle(UpdateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _programmingLanguageTechnologyBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicated(request.Name);

            var programmingLanguageTechnology = await _programmingLanguageLanguageTechnologyRepository.Query().AsNoTracking().FirstOrDefaultAsync(x => 
                x.Id == request.Id,
                cancellationToken: cancellationToken);
            
            await _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageMustExistAsync(request.ProgrammingLanguageId);
            _programmingLanguageTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingLanguageTechnology);

            var mappedProgrammingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
            var updatedProgrammingLanguageTechnology = await _programmingLanguageLanguageTechnologyRepository.UpdateAsync(mappedProgrammingLanguageTechnology);
            var mappedProgrammingLanguageTechnologyDto = _mapper.Map<UpdatedProgrammingLanguageTechnologyDto>(updatedProgrammingLanguageTechnology);
            return mappedProgrammingLanguageTechnologyDto;
        }
    }
}