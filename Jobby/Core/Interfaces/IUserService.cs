using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<RegistrationResponseDto> RegisterUser(RegistrationDto registration);
        Task<AuthResponseDto> Login(LoginDto login);
        Task<IList<AppUser>> GetAllEmployers();
        Task<IList<AppUser>> GetAllFreelancers();
        Task<AppUser> GetUserById(string id);
    }
}
