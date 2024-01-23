using Guest_BO.DTOModel.User;

namespace Guest_DAL.IRepository
{
    public interface IUserRepository
    {
        Task<bool> isUniqueUserAsync(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
