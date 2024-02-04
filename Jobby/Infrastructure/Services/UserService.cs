using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;
        private const string EmployerRole = "Employer";
        private const string Freelancer = "Freelancer";

        public UserService(UserManager<AppUser> userManager, IMapper mapper, TokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto> Login(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
                return new AuthResponseDto { ErrorMessage = "Invalid Authentication" };

            var signingCredentials = _tokenService.GetSigningCredentials();
            var claims = _tokenService.GetClaims(user);
            var tokenOptions = _tokenService.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new AuthResponseDto { IsAuthSuccessful = true, Token = token };
        }
        public async Task<RegistrationResponseDto> RegisterUser(RegistrationDto registration)
        {
            if (registration == null)
            {
                throw new ArgumentNullException(nameof(registration));
            }
            var user = _mapper.Map<AppUser>(registration);
            var result = await _userManager.CreateAsync(user, registration.Password);
            await _userManager.AddToRoleAsync(user, registration.Role);

            if (result.Succeeded)
            {
                return new RegistrationResponseDto();
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description);
                return new RegistrationResponseDto { Errors = errors };
            }
        }
        public Task<IList<AppUser>> GetAllEmployers()
        {
            var users = _userManager.GetUsersInRoleAsync(EmployerRole);
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            return users;
        }

        public Task<IList<AppUser>> GetAllFreelancers()
        {
            var users = _userManager.GetUsersInRoleAsync(Freelancer);
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            return users;
        }

        public Task<AppUser> GetUserById(string id)
        {
            var user = _userManager.FindByIdAsync(id);
            return user ?? null;
        }
    }
}
