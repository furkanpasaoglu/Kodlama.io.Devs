using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.OperationClaims.Constants;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;

/// <summary>
/// Operasyon Claim için sorgu sınıfı
/// </summary>
public class GetByIdOperationClaimQuery : IRequest<OperationClaimGetByIdDto>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles { get; } =
    {
        OperationClaimRoles.OperationClaimAdmin,
        OperationClaimRoles.OperationClaimRead
    };
    
    /// <summary>
    /// Operasyon Claim Getirmek için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery,OperationClaimGetByIdDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<OperationClaimGetByIdDto> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules.OperationClaimIdShouldBeExist(request.Id);
            
            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
            var mappedOperationClaim = _mapper.Map<OperationClaimGetByIdDto>(operationClaim);
            return mappedOperationClaim;
        }
    }
}