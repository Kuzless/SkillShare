using MediatR;
using SkillShare.Application.DTOs;

namespace SkillShare.Application.CQRS.User.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<TokensDTO>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public CreateUserCommand(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
