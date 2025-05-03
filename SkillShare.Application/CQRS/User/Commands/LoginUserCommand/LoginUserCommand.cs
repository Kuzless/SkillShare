using MediatR;
using SkillShare.Application.DTOs;

namespace SkillShare.Application.CQRS.User.Commands.LoginUserCommand
{
    public class LoginUserCommand : IRequest<TokensDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
