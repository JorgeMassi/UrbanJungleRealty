using UrbanJungleRealty.Application.Dtos.LoginDto;
using UrbanJungleRealty.Application.Interfaces.Profile.Accounts;
using UrbanJungleRealty.Application.Interfaces.Profile.DataProtection;
using UrbanJungleRealty.Application.Interfaces.Profile.Token;
using UrbanJungleRealty.Application.Interfaces.Profile.Users;

namespace UrbanJungleRealty.Application.Services.Profile
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repository;
        private readonly IDataProtectionService _dataProtectionService;
        private readonly ITokenService _tokenService;

        public AccountService(IUserRepository repository, IDataProtectionService dataProtectionService, ITokenService tokenService)
        {
            _repository = repository;
            _dataProtectionService = dataProtectionService;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _repository.GetByUsername(loginRequestDto.Username);

            if (user is null)
            {
                //_logger.LogInformation("User not found");
                throw new Exception($"User {loginRequestDto.Username} not found!");
            }

            var hashedPassword = _dataProtectionService.GetComputedHash(loginRequestDto.Password, user.Account.PasswordSaltHash);

            for (int i = 0; i < hashedPassword.Length; i++)
            {
                if (hashedPassword[i] != user.Account.PasswordHash[i])
                {
                    // _logger.LogInformation("Username / password does not match");
                    throw new Exception("Username or password incorrect!");
                }
            }

            return _tokenService.GenerateToken(user);
        }
    }
}
