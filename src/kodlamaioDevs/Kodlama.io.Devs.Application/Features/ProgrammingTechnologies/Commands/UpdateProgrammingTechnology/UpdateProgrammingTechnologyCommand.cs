using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;

/// <summary>
/// Programlama Teknolojisi Güncelleme Komutu
/// </summary>
public class UpdateProgrammingTechnologyCommand : IRequest<UpdatedProgrammingTechnologyDto>
{
    public int Id { get; set; }
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
    
    /// <summary>
    /// Programlama Teknolojisi Güncellemek için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class UpdateProgrammingTechnologyCommandHandler : IRequestHandler<UpdateProgrammingTechnologyCommand,UpdatedProgrammingTechnologyDto>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

        public UpdateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
            _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
        }

        public async Task<UpdatedProgrammingTechnologyDto> Handle(UpdateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _programmingTechnologyBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicated(request.Name);

            var programmingTechnology = await _programmingTechnologyRepository.Query().AsNoTracking().FirstOrDefaultAsync(x => 
                x.Id == request.Id,
                cancellationToken: cancellationToken);
            
            await _programmingTechnologyBusinessRules.ProgrammingLanguageMustExistAsync(request.ProgrammingLanguageId);
            _programmingTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingTechnology);

            var mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);
            var updatedProgrammingTechnology = await _programmingTechnologyRepository.UpdateAsync(mappedProgrammingTechnology);
            var mappedProgrammingTechnologyDto = _mapper.Map<UpdatedProgrammingTechnologyDto>(updatedProgrammingTechnology);
            return mappedProgrammingTechnologyDto;
        }
    }
}