using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;

/// <summary>
/// Kullanıcı Operasyon Claim için sorgu sınıfı
/// </summary>
public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public string[] Roles { get; } =
    {
        UserOperationClaimRoles.UserOperationClaimAdmin,
        UserOperationClaimRoles.UserOperationClaimRead
    };
    
    /// <summary>
    /// Kullanıcı Operasyon Claim Listelemek için kullanılan işleyici sınıfıdır.
    /// </summary>
    public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery,UserOperationClaimListModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            var userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                index:request.PageRequest.Page, 
                size:request.PageRequest.PageSize, 
                include:
                m => m.Include(c => c.User).Include(x=>x.OperationClaim),
                cancellationToken: cancellationToken);
            
            var userOperationClaimListModel = _mapper.Map<UserOperationClaimListModel>(userOperationClaims);
            return userOperationClaimListModel;
        }
    }
}