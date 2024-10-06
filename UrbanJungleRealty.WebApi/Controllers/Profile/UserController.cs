using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbanJungleRealty.Application.Interfaces.Profile.Users;
using UrbanJungleRealty.Domain.Model.Profile;

namespace UrbanJungleRealty.WebApi.Controllers.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.GetAll();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public User Put(int id, [FromBody] User user)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _userService.Delete(id);
        }
    }
}
