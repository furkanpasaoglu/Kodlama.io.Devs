using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

/// <summary>
/// Kullanıcı Operasyon claim silme komutu
/// </summary>
public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles { get; } =
    {
        UserOperationClaimRoles.UserOperationClaimAdmin,
        UserOperationClaimRoles.UserOperationClaimDelete
    };
    
    /// <summary>
    /// Kullanıcı Operasyon claim silme işleyicisi
    /// </summary>
    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand,DeletedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
        private readonly IMapper _mapper;

        public DeleteOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.UserOperationClaimIdShouldBeExist(request.Id);
            
            var userOperationClaim = await _userOperationClaimRepository.GetAsync(x=> x.Id == request.Id);
            var deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userOperationClaim);
            var mappedUserOperationClaim = _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);
            return mappedUserOperationClaim;
        }   
    }
}