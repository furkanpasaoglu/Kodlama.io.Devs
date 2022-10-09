using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

/// <summary>
/// Kullanıcı Operasyon claim güncelleme komutu
/// </summary>
public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>, ISecuredRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
    public string[] Roles { get; } =
    {
        UserOperationClaimRoles.UserOperationClaimAdmin,
        UserOperationClaimRoles.UserOperationClaimUpdate
    };
    
    /// <summary>
    /// Kullanıcı Operasyon claim güncelleme işleyicisi
    /// </summary>
    public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand,UpdatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
        private readonly IMapper _mapper;

        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.UserOperationClaimIdShouldBeExist(request.Id);
            await _userOperationClaimBusinessRules.UserIdAndOperationClaimIdCanNotBeDuplicatedWhenRequested(request.UserId, request.OperationClaimId);
            await _userOperationClaimBusinessRules.CheckIfUserExists(request.UserId); 
            await _userOperationClaimBusinessRules.CheckIfOperationClaimExists(request.OperationClaimId); 
            
            var userOperationClaim = await _userOperationClaimRepository.GetAsync(x=> x.Id == request.Id);
            var mappedUserOperationClaim = _mapper.Map(request, userOperationClaim);
            var updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);
            var mappedUpdatedUserOperationClaim = _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);
            return mappedUpdatedUserOperationClaim;
        }
    }
}