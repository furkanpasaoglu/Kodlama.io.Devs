using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Constants;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnologyByDynamic;

/// <summary>
/// Programlama dili teknolojisi için sorgu sınıfı
/// </summary>
public class GetListProgrammingLanguageTechnologyByDynamicQuery : IRequest<ProgrammingLanguageTechnologyListModel>, ISecuredRequest
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }
    public string[] Roles { get; } =
    {
        ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyAdmin,
        ProgrammingLanguageTechnologyRoles.ProgrammingLanguageTechnologyRead
    };

    /// <summary>
    /// Programlama dili teknolojisi için işleyici sınıfı
    /// </summary>
    public class GetListProgrammingLanguageTechnologyByDynamicQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologyByDynamicQuery,ProgrammingLanguageTechnologyListModel>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageLanguageTechnologyRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageTechnologyByDynamicQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageLanguageTechnologyRepository, IMapper mapper)
        {
            _programmingLanguageLanguageTechnologyRepository = programmingLanguageLanguageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListProgrammingLanguageTechnologyByDynamicQuery request, CancellationToken cancellationToken)
        {
            var programmingLanguageTechnologies = await _programmingLanguageLanguageTechnologyRepository.GetListByDynamicAsync(request.Dynamic,include:
                m => m.Include(c => c.ProgrammingLanguage),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken);
            
            var mappedProgrammingLanguageTechnologies = _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologies);
            return mappedProgrammingLanguageTechnologies;
        }
    }
}