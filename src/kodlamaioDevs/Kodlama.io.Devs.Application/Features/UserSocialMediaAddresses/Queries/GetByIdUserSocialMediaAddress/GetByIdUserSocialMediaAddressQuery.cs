using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Constants;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Dtos;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Queries.GetByIdUserSocialMediaAddress;

/// <summary>
/// İstenilen kullanıcı sosyal medya adresi isteği
/// </summary>
public class GetByIdUserSocialMediaAddressQuery : IRequest<UserSocialMediaAddressGetByIdDto>, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles { get; } =
    {
        UserSocialMediaAddressRoles.UserSocialMediaAddressAdmin,
        UserSocialMediaAddressRoles.UserSocialMediaAddressRead
    };

    /// <summary>
    /// Kullanıcı Sosyal Medya Adresi Getirmek için işleyici sınıfı.
    /// </summary>
    public class GetByIdUserSocialMediaAddressQueryHandler : IRequestHandler<GetByIdUserSocialMediaAddressQuery,UserSocialMediaAddressGetByIdDto>
    {
        private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
        private readonly IMapper _mapper;
        private readonly UserSocialMediaAddressBusinessRules _userSocialMediaAddressBusinessRules;

        public GetByIdUserSocialMediaAddressQueryHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressBusinessRules userSocialMediaAddressBusinessRules)
        {
            _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
            _mapper = mapper;
            _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
        }

        public async Task<UserSocialMediaAddressGetByIdDto> Handle(GetByIdUserSocialMediaAddressQuery request, CancellationToken cancellationToken)
        {
            var userSocialMediaAddress = await _userSocialMediaAddressRepository.Query().Include(x=>x.User).FirstOrDefaultAsync(x=> 
                x.Id == request.Id, 
                cancellationToken: cancellationToken);
            
            _userSocialMediaAddressBusinessRules.SocialMediaAddressShouldExistWhenRequested(userSocialMediaAddress);
            
            var userSocialMediaAddressGetByIdDto = _mapper.Map<UserSocialMediaAddressGetByIdDto>(userSocialMediaAddress);
            return userSocialMediaAddressGetByIdDto;
        }
    }
}