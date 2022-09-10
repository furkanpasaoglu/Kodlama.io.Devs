using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Dtos;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.DeleteUserSocialMediaAddress;

/// <summary>
/// Silinecek Kullanıcı Sosyal Medya Adresinin İstek Komutudur.
/// </summary>
public class DeleteUserSocialMediaAddressCommand : IRequest<DeletedUserSocialMediaAddressDto>, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles { get; } = { "User" };

    /// <summary>
    /// Silinecek Kullanıcı Sosyal Medya Adresinin İşleyici Sınıfıdır.
    /// </summary>
    public class DeleteUserSocialMediaAddressCommandHandler : IRequestHandler<DeleteUserSocialMediaAddressCommand,DeletedUserSocialMediaAddressDto>
    {
        private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
        private readonly IMapper _mapper;
        private readonly UserSocialMediaAddressBusinessRules _userSocialMediaAddressBusinessRules;

        public DeleteUserSocialMediaAddressCommandHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressBusinessRules userSocialMediaAddressBusinessRules)
        {
            _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
            _mapper = mapper;
            _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
        }

        public async Task<DeletedUserSocialMediaAddressDto> Handle(DeleteUserSocialMediaAddressCommand request, CancellationToken cancellationToken)
        {
            var userSocialMediaAddress = await _userSocialMediaAddressRepository.GetAsync(x=>x.Id==request.Id);
            _userSocialMediaAddressBusinessRules.SocialMediaAddressShouldExistWhenRequested(userSocialMediaAddress);
            
            var deletedUserSocialMediaAddress = await _userSocialMediaAddressRepository.DeleteAsync(userSocialMediaAddress);
            var mappedDeletedUserSocialMediaAddressDto = _mapper.Map<DeletedUserSocialMediaAddressDto>(deletedUserSocialMediaAddress);
            return mappedDeletedUserSocialMediaAddressDto;
        }
    }
}