using UrbanJungleRealty.Application.Dtos.LoginDto;

namespace UrbanJungleRealty.Application.Interfaces.Profile.Accounts
{
    public interface IAccountService
    {
        public Task<string> Login(LoginRequestDto loginRequestDto);
    }
}
