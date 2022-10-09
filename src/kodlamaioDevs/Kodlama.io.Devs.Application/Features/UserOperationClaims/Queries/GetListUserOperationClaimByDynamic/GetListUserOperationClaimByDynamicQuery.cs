using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaimByDynamic;

/// <summary>
/// Kullanıcı Operasyon Claim için sorgu sınıfı
/// </summary>
public class GetListUserOperationClaimByDynamicQuery : IRequest<UserOperationClaimListModel>, ISecuredRequest
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }
    public string[] Roles { get; } =
    {
        UserOperationClaimRoles.UserOperationClaimAdmin,
        UserOperationClaimRoles.UserOperationClaimRead
    };
    
    public class GetListUserOperationClaimByDynamicQueryHandler : IRequestHandler<GetListUserOperationClaimByDynamicQuery,UserOperationClaimListModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetListUserOperationClaimByDynamicQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimByDynamicQuery request, CancellationToken cancellationToken)
        {
            var userOperationClaims = await _userOperationClaimRepository.GetListByDynamicAsync(request.Dynamic,include:
                m => m.Include(c => c.User).Include(x=>x.OperationClaim),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken);
            
            var mappedUserOperationClaims = _mapper.Map<UserOperationClaimListModel>(userOperationClaims);
            return mappedUserOperationClaims;
        }
    }
}