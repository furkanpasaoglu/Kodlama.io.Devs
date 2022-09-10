using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology;

/// <summary>
/// Programlama teknolojisi için sorgu sınıfı
/// </summary>
public class GetListProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyListModel>,ISecuredRequest
{
    public PageRequest PageRequest { get; set; }    public string[] Roles { get; } = { "User" };

    
    /// <summary>
    /// Programlama teknolojisi için işleyici sınıfı
    /// </summary>
    public class GetListProgrammingTechnologyQueryHandler : IRequestHandler<GetListProgrammingTechnologyQuery, ProgrammingTechnologyListModel>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingTechnologyQuery request, CancellationToken cancellationToken)
        {
            var programmingTechnologies = await _programmingTechnologyRepository.GetListAsync(include:m=>
                m.Include(c=>c.ProgrammingLanguage),
                index: request.PageRequest.Page,
                size:request.PageRequest.PageSize, 
                cancellationToken: cancellationToken);
            
            var programmingTechnologyListModel = _mapper.Map<ProgrammingTechnologyListModel>(programmingTechnologies);
            return programmingTechnologyListModel;
        }
    }
}