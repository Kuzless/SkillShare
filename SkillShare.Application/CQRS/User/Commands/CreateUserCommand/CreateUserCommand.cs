using MediatR;

namespace SkillShare.Application.CQRS.User.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public CreateUserCommand(string name, string email, string password, string token, string refreshtoken)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            Token = token;
            RefreshToken = refreshtoken;
        }
    }
}
