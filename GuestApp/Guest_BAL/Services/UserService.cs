using Guest_BAL.IServices;
using Guest_BO.DTOModel.User;
using Guest_DAL.IRepository;

namespace Guest_BAL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> isUniqueUser(string username)
        {
            return await _userRepository.isUniqueUserAsync(username);
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            return await _userRepository.Login(loginRequestDTO);
        }

        public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _userRepository.Register(registrationRequestDTO);
        }
    }
}
