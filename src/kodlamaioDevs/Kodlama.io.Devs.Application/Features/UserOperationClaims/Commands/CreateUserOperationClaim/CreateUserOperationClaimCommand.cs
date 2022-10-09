using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

/// <summary>
/// Kullanıcı Operasyon claim oluşturma komutu
/// </summary>
public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>, ISecuredRequest
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
    public string[] Roles { get; } =
    {
        UserOperationClaimRoles.UserOperationClaimAdmin,
        UserOperationClaimRoles.UserOperationClaimCreate
    };
    
    /// <summary>
    /// Kullanıcı Operasyon claim oluşturma işleyicisi
    /// </summary>
    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand,CreatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
        private readonly IMapper _mapper;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.UserIdAndOperationClaimIdCanNotBeDuplicatedWhenRequested(request.UserId,request.OperationClaimId);
            await _userOperationClaimBusinessRules.CheckIfUserExists(request.UserId); 
            await _userOperationClaimBusinessRules.CheckIfOperationClaimExists(request.OperationClaimId); 
            
            var mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
            var createdUserOperationClaim = _userOperationClaimRepository.Add(mappedUserOperationClaim);
            var mappedCreatedUserOperationClaim = _mapper.Map<CreatedUserOperationClaimDto>(createdUserOperationClaim);
            return mappedCreatedUserOperationClaim;
        }
    }
}