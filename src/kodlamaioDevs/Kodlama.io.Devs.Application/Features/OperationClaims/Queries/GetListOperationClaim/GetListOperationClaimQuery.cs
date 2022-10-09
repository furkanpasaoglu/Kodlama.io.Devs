using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.OperationClaims.Constants;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;

/// <summary>
/// Operasyon Claim için sorgu sınıfı
/// </summary>
public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public string[] Roles { get; } =
    {
        OperationClaimRoles.OperationClaimAdmin,
        OperationClaimRoles.OperationClaimRead
    };
    
    /// <summary>
    /// Operasyon Claim Listelemek için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery,OperationClaimListModel>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
        {
            var operationClaims = await _operationClaimRepository.GetListAsync(index:request.PageRequest.Page, 
                size:request.PageRequest.PageSize, 
                cancellationToken: cancellationToken);
            
            var operationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);
            return operationClaimListModel;

        }
    }
}