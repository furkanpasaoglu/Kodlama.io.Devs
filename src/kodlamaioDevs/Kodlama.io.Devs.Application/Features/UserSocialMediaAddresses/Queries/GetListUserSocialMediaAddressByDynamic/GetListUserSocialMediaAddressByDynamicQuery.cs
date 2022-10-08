using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Constants;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddressByDynamic;

/// <summary>
/// Tüm kullanıcıların sosyal medya adresi isteği
/// </summary>
public class GetListUserSocialMediaAddressByDynamicQuery : IRequest<UserSocialMediaAddressListModel>, ISecuredRequest
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }
    public string[] Roles { get; } =
    {
        UserSocialMediaAddressRoles.UserSocialMediaAddressAdmin,
        UserSocialMediaAddressRoles.UserSocialMediaAddressRead
    };

    /// <summary>
    /// Tüm kullanıcıların sosyal medya adresi için işleyici sınıfı
    /// </summary>
    public class GetListUserSocialMediaAddressByDynamicQueryHandler : IRequestHandler<GetListUserSocialMediaAddressByDynamicQuery,UserSocialMediaAddressListModel>
    {
        private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
        private readonly IMapper _mapper;

        public GetListUserSocialMediaAddressByDynamicQueryHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper)
        {
            _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
            _mapper = mapper;
        }

        public async Task<UserSocialMediaAddressListModel> Handle(GetListUserSocialMediaAddressByDynamicQuery request, CancellationToken cancellationToken)
        {
            var userSocialMediaAddresses = await _userSocialMediaAddressRepository.GetListByDynamicAsync(request.Dynamic,include:
                m => m.Include(c => c.User),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken);
            
            var mappedSocialMediaAddressListModel = _mapper.Map<UserSocialMediaAddressListModel>(userSocialMediaAddresses);
            return mappedSocialMediaAddressListModel;
        }
    }
}