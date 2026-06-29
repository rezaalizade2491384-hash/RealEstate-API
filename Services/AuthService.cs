using Microsoft.AspNetCore.Identity;
using RealEstate.Api.Data.Entities;
using RealEstate.Api.DTOs;

namespace RealEstate.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public AuthService(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto?> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                // نمایش خطاهای دقیق در ترمینال
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Registration failed: {errors}");
            }

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                ExpiresAt = DateTime.Now.AddMinutes(60),
                Email = user.Email ?? string.Empty,
                FullName = $"{user.FirstName ?? string.Empty} {user.LastName ?? string.Empty}".Trim()
            };
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return null;

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                ExpiresAt = DateTime.Now.AddMinutes(60),
                Email = user.Email ?? string.Empty,
                FullName = $"{user.FirstName ?? string.Empty} {user.LastName ?? string.Empty}".Trim()
            };
        }
    }
}