using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Constants;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

/// <summary>
/// Operasyon claim oluşturma komutu
/// </summary>
public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>, ISecuredRequest
{
    public string Name { get; set; }
    public string[] Roles { get; } =
    {
        OperationClaimRoles.OperationClaimAdmin,
        OperationClaimRoles.OperationClaimCreate
    };
    
    /// <summary>
    /// Operasyon claim oluşturma işleyicisi
    /// </summary>
    public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand,CreatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
        private readonly IMapper _mapper;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _operationClaimBusinessRules = operationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules.NameCanNotBeDuplicatedWhenRequested(request.Name);
            
            var mappedOperationClaim = _mapper.Map<OperationClaim>(request);
            var createdOperationClaim = _operationClaimRepository.Add(mappedOperationClaim);
            var mappedCreatedOperationClaim = _mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);
            return mappedCreatedOperationClaim;
        }
    }
}