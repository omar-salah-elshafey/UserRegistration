using UserRegistration.Models;

namespace UserRegistration.Services
{
    public interface IUserService
    {
        Task<ResponseModel> RegisterAsync(RegistrationModel registrationModel);
        Task<IEnumerable<UserDto>> GetAllAsync();
    }
}
