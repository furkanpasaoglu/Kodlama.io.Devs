using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.OperationClaims.Constants;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

/// <summary>
/// Operasyon claim silme komutu
/// </summary>
public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles { get; } =
    {
        OperationClaimRoles.OperationClaimAdmin,
        OperationClaimRoles.OperationClaimDelete
    };
    
    /// <summary>
    /// Operasyon claim silme işleyicisi
    /// </summary>
    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand,DeletedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
        private readonly IMapper _mapper;

        public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _operationClaimBusinessRules = operationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules.OperationClaimIdShouldBeExist(request.Id);
            
            var operationClaim = await _operationClaimRepository.GetAsync(x=> x.Id == request.Id);
            var deletedOperationClaim = await _operationClaimRepository.DeleteAsync(operationClaim);
            var mappedOperationClaim = _mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);
            return mappedOperationClaim;
        }
    }
}