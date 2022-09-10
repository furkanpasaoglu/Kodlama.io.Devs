using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Dtos;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress;

/// <summary>
/// Oluşturlacak Kullanıcı Sosyal Medya Adresinin İstek Komutudur.
/// </summary>
public class CreateUserSocialMediaAddressCommand : IRequest<CreatedUserSocialMediaAddressDto>, ISecuredRequest
{
    public int UserId { get; set; }
    public string GithubUrl { get; set; }
    public string[] Roles { get; } = { "User" };

    /// <summary>
    /// Oluşturlacak Kullanıcı Sosyal Medya Adresinin İşleyici Sınıfıdır.
    /// </summary>
    public class CreateUserSocialMediaAddressCommandHandler : IRequestHandler<CreateUserSocialMediaAddressCommand,CreatedUserSocialMediaAddressDto>
    {
        private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
        private readonly IMapper _mapper;
        private readonly UserSocialMediaAddressBusinessRules _userSocialMediaAddressBusinessRules;

        public CreateUserSocialMediaAddressCommandHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressBusinessRules userSocialMediaAddressBusinessRules)
        {
            _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
            _mapper = mapper;
            _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
        }

        public async Task<CreatedUserSocialMediaAddressDto> Handle(CreateUserSocialMediaAddressCommand request, CancellationToken cancellationToken)
        {
            await _userSocialMediaAddressBusinessRules.UserSocialMediaAddressGithubUrlCanNotBeDuplicated(request.GithubUrl);
            await _userSocialMediaAddressBusinessRules.UserMustBeExist(request.UserId);
            await _userSocialMediaAddressBusinessRules.UserSocialMediaAddressCanNotHaveMoreThanOneGithubAddress(request.UserId); 
            
            var mappedUserSocialMediaAddress = _mapper.Map<UserSocialMediaAddress>(request);
            var createdUserSocialMediaAddress = await _userSocialMediaAddressRepository.AddAsync(mappedUserSocialMediaAddress);
            var mappedCreatedUserSocialMediaAddressDto = _mapper.Map<CreatedUserSocialMediaAddressDto>(createdUserSocialMediaAddress);
            return mappedCreatedUserSocialMediaAddressDto;
        }
    }
}