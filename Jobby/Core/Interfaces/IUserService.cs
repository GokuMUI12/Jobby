using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<RegistrationResponseDto> RegisterUser(RegistrationDto registration);
        Task<AuthResponseDto> Login(LoginDto login);
        Task<IReadOnlyList<UserToReturnDto>> GetAllEmployers();
        Task<IReadOnlyList<UserToReturnDto>> GetAllFreelancers();
        Task<UserToReturnDto> GetUserById(string id);
    }
}
