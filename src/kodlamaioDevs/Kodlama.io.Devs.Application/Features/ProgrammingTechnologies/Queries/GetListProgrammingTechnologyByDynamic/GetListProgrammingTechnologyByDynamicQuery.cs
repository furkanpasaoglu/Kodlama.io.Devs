using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyByDynamic;

/// <summary>
/// Programlama teknolojisi için sorgu sınıfı
/// </summary>
public class GetListProgrammingTechnologyByDynamicQuery : IRequest<ProgrammingTechnologyListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }
    
    /// <summary>
    /// Programlama teknolojisi için işleyici sınıfı
    /// </summary>
    public class GetListProgrammingTechnologyByDynamicQueryHandler : IRequestHandler<GetListProgrammingTechnologyByDynamicQuery,ProgrammingTechnologyListModel>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingTechnologyByDynamicQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingTechnologyByDynamicQuery request, CancellationToken cancellationToken)
        {
            var models = await _programmingTechnologyRepository.GetListByDynamicAsync(request.Dynamic,include:
                m => m.Include(c => c.ProgrammingLanguage),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken);
            
            var mappedprogrammingTechnologies = _mapper.Map<ProgrammingTechnologyListModel>(models);
            return mappedprogrammingTechnologies;
        }
    }
}