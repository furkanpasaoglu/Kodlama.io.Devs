using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Auths.Dtos;
using Kodlama.io.Devs.Application.Features.Auths.Rules;
using Kodlama.io.Devs.Application.Services.AuthService;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Register;

/// <summary>
/// Kullanıcı kayıt işlemini gerçekleştiren komut sınıfı
/// </summary>
public class RegisterCommand : IRequest<RegisteredDto>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }
    
    /// <summary>
    /// Kullanıcı kayıt işlemini gerçekleştiren işleyici sınıfı
    /// </summary>
    public class RegisterCommandHandler: IRequestHandler<RegisterCommand,RegisteredDto>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public RegisterCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
        {
            _authBusinessRules = authBusinessRules;
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.UserForRegisterDto.Email);
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out var passwordHash, out var passwordSalt);
            
            var user = new User
            {
                Email = request.UserForRegisterDto.Email,
                FirstName = request.UserForRegisterDto.FirstName,
                LastName = request.UserForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            var createdUser = await _userRepository.AddAsync(user);
            var createdAccessToken = await _authService.CreateAccessToken(createdUser);
            var createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
            var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
            
            return new RegisteredDto
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken
            };
        }
    }
}