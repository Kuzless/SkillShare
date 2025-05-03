using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SkillShare.Application.DTOs;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;
        private User user;
        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokensDTO GenerateTokens(User user)
        {
            this.user = user;
            var bearerToken = GenerateBearerToken();
            var refreshToken = GenerateRefreshToken();
            return new TokensDTO
            {
                BearerToken = bearerToken,
                RefreshToken = refreshToken
            };
        }

        private string GenerateBearerToken()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()!),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, string.Join(",", user.Roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var accessToken = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(accessToken);
        }
        private string GenerateRefreshToken()
        {
            var refreshToken = Guid.NewGuid().ToString();
            return refreshToken;
        }
    }
}
