using Microsoft.AspNetCore.Mvc;
using UrbanJungleRealty.Application.Dtos.LoginDto;
using UrbanJungleRealty.Application.Dtos.RegisterDto;
using UrbanJungleRealty.Application.Interfaces.Profile.Accounts;
using UrbanJungleRealty.Application.Interfaces.Profile.Users;
using UrbanJungleRealty.Domain.Model.Profile;

namespace UrbanJungleRealty.WebApi.Controllers.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AuthenticationController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<string> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            return await _accountService.Login(loginRequestDto);
        }

        [HttpPost("register")]
        public async Task<User> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            return await _userService.Create(registerRequestDto);
        }
    }
}
