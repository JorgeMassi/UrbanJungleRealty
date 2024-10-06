using UrbanJungleRealty.Application.Dtos.RegisterDto;
using UrbanJungleRealty.Domain.Model.Profile;

namespace UrbanJungleRealty.Application.Interfaces.Profile.Users
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<User> GetByUsername(string username);
        Task<User> Create(RegisterRequestDto registerRequestDto);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Delete(User user);
        Task<User> Delete(Guid id);
    }
}
