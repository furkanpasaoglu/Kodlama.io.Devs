using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguageByDynamic;

/// <summary>
/// Programlama dili için sorgu sınıfı
/// </summary>
public class GetListProgrammingLanguageByDynamicQuery  : IRequest<ProgrammingLanguageListModel>, ISecuredRequest
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }
    
    public string[] Roles { get; } = { "User" };

    /// <summary>
    /// Programlama dili için işleyici sınıfı
    /// </summary>
    public class GetListProgrammingLanguageByDynamicQueryHandler : IRequestHandler<GetListProgrammingLanguageByDynamicQuery,ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageByDynamicQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageByDynamicQuery request, CancellationToken cancellationToken)
        {
            var models = await _programmingLanguageRepository.GetListByDynamicAsync(request.Dynamic,include:
                m => m.Include(c => c.ProgrammingLanguageTechnologies),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken);
            
            var mappedProgrammingLanguages = _mapper.Map<ProgrammingLanguageListModel>(models);
            return mappedProgrammingLanguages;
        }
    }
}