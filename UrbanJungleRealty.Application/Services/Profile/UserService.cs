using UrbanJungleRealty.Application.Dtos.RegisterDto;
using UrbanJungleRealty.Application.Interfaces.Profile.DataProtection;
using UrbanJungleRealty.Application.Interfaces.Profile.Users;
using UrbanJungleRealty.Application.Interfaces.UnitOfWork;
using UrbanJungleRealty.Domain.Model.Profile;

namespace UrbanJungleRealty.Application.Services.Profile
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataProtectionService _dataProtectionService;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IDataProtectionService dataProtectionService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _dataProtectionService = dataProtectionService;
        }

        public Task<User> Create(RegisterRequestDto registerRequestDto)
        {
            var dataProtectionKeys = _dataProtectionService.Protect(registerRequestDto.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = registerRequestDto.Name,
                Account = new Account
                {
                    Id = Guid.NewGuid(),
                    Username = registerRequestDto.Username,
                    PasswordHash = dataProtectionKeys.PasswordHash,
                    PasswordSaltHash = dataProtectionKeys.PasswordSalt,
                }
            };
            _repository.Create(user);
            _unitOfWork.Commit();

            return Task.FromResult(user);
        }
        public async Task<User> Create(User user)
        {
            //verify
            user.Id = Guid.NewGuid();
            var entity = await _repository.Create(user);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task<User> Delete(User user)
        {
            var entity = _repository.Delete(user);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task<User> Delete(Guid id)
        {
            var entity = await _repository.Delete(id);
            await _unitOfWork.Commit();
            return entity;
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<User> GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public async Task<User> Update(User user)
        {
            var entity = _repository.Update(user);
            await _unitOfWork.Commit();
            return entity;
        }
        public async Task<User> GetByUsername(string username)
        {
            return await _repository.GetByUsername(username);
        }
    }
}
