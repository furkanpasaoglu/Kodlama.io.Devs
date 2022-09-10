using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology;

/// <summary>
/// Programlama dili teknolojisi için sorgu sınıfı
/// </summary>
public class GetListProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyListModel>,ISecuredRequest
{
    public PageRequest PageRequest { get; set; }    public string[] Roles { get; } = { "User" };

    
    /// <summary>
    /// Programlama teknolojisi için işleyici sınıfı
    /// </summary>
    public class GetListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyListModel>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageLanguageTechnologyRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageLanguageTechnologyRepository, IMapper mapper)
        {
            _programmingLanguageLanguageTechnologyRepository = programmingLanguageLanguageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
        {
            var programmingLanguageTechnologies = await _programmingLanguageLanguageTechnologyRepository.GetListAsync(include:m=>
                m.Include(c=>c.ProgrammingLanguage),
                index: request.PageRequest.Page,
                size:request.PageRequest.PageSize, 
                cancellationToken: cancellationToken);
            
            var programmingLanguageTechnologyListModel = _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologies);
            return programmingLanguageTechnologyListModel;
        }
    }
}