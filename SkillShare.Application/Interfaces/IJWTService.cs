using SkillShare.Application.DTOs;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Interfaces
{
    public interface IJWTService
    {
        TokensDTO GenerateTokens(User user);
    }
}
