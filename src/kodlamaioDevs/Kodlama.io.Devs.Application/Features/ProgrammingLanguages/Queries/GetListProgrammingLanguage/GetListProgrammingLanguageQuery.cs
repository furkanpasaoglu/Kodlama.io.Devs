using AutoMapper;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

/// <summary>
/// Programlama dili için sorgu sınıfı
/// </summary>
public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
{
    public PageRequest PageRequest { get; set; }
    
    /// <summary>
    /// Programlama Dili Listelemek için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery,ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            var programmingLanguages = await _programmingLanguageRepository.GetListAsync(
                include:m=>m.Include(x=>x.ProgrammingTechnologies),
                index:request.PageRequest.Page, 
                size:request.PageRequest.PageSize, 
                cancellationToken: cancellationToken);
            var programmingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguages);
            return programmingLanguageListModel;
        }
    }
}