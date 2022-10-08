using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Constants;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddress;

/// <summary>
/// Tüm kullanıcıların sosyal medya adresi isteği
/// </summary>
public class GetListUserSocialMediaAddressQuery : IRequest<UserSocialMediaAddressListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    
    public string[] Roles { get; } =
    {
        UserSocialMediaAddressRoles.UserSocialMediaAddressAdmin,
        UserSocialMediaAddressRoles.UserSocialMediaAddressRead
    };
    

    /// <summary>
    /// Tüm Kullanıcıların sosyal medya adresini getirmek için işleyici sınıfı.
    /// </summary>
    public class GetListUserSocialMediaAddressQueryHandler : IRequestHandler<GetListUserSocialMediaAddressQuery,UserSocialMediaAddressListModel>
    {
        private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
        private readonly IMapper _mapper;

        public GetListUserSocialMediaAddressQueryHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper)
        {
            _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
            _mapper = mapper;
        }

        public async Task<UserSocialMediaAddressListModel> Handle(GetListUserSocialMediaAddressQuery request, CancellationToken cancellationToken)
        {
            var userSocialMediaAddresses = await _userSocialMediaAddressRepository.GetListAsync(include:m=>
                    m.Include(c=>c.User),
                index: request.PageRequest.Page,
                size:request.PageRequest.PageSize, 
                cancellationToken: cancellationToken);
            
            var userSocialMediaAddressListModel = _mapper.Map<UserSocialMediaAddressListModel>(userSocialMediaAddresses);
            return userSocialMediaAddressListModel;
        }
    }
}