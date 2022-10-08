using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Constants;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Dtos;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress;

/// <summary>
/// Güncellenecek Kullanıcı Sosyal Medya Adresinin İstek Komutudur.
/// </summary>
public class UpdateUserSocialMediaAddressCommand : IRequest<UpdatedUserSocialMediaAddressDto>, ISecuredRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string GithubUrl { get; set; }
    public string[] Roles { get; } =
    {
        UserSocialMediaAddressRoles.UserSocialMediaAddressAdmin,
        UserSocialMediaAddressRoles.UserSocialMediaAddressUpdate
    };

    /// <summary>
    /// Güncellenecek Kullanıcı Sosyal Medya Adresinin İşleyici Sınıfıdır.
    /// </summary>
    public class UpdateUserSocialMediaAddressCommandHandler : IRequestHandler<UpdateUserSocialMediaAddressCommand,UpdatedUserSocialMediaAddressDto>
    {
        private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
        private readonly IMapper _mapper;
        private readonly UserSocialMediaAddressBusinessRules _userSocialMediaAddressBusinessRules;

        public UpdateUserSocialMediaAddressCommandHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressBusinessRules userSocialMediaAddressBusinessRules)
        {
            _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
            _mapper = mapper;
            _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
            // Added User Social Media Address Entity
        }

        public async Task<UpdatedUserSocialMediaAddressDto> Handle(UpdateUserSocialMediaAddressCommand request, CancellationToken cancellationToken)
        {
            await _userSocialMediaAddressBusinessRules.UserSocialMediaAddressGithubUrlCanNotBeDuplicated(request.GithubUrl); 
            
            var programmingTechnology = await _userSocialMediaAddressRepository.Query().AsNoTracking().FirstOrDefaultAsync(x => 
                    x.Id == request.Id,
                cancellationToken: cancellationToken);

            await _userSocialMediaAddressBusinessRules.UserMustBeExist(request.UserId);
            _userSocialMediaAddressBusinessRules.SocialMediaAddressShouldExistWhenRequested(programmingTechnology);
            
            var mappedUserSocialMediaAddress = _mapper.Map<UserSocialMediaAddress>(request);
            var updatedUserSocialMediaAddress = await _userSocialMediaAddressRepository.UpdateAsync(mappedUserSocialMediaAddress);
            var mappedUpdatedUserSocialMediaAddressDto = _mapper.Map<UpdatedUserSocialMediaAddressDto>(updatedUserSocialMediaAddress);
            return mappedUpdatedUserSocialMediaAddressDto;
        }
    }
}