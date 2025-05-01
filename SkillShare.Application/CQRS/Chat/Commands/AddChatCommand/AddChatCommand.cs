using MediatR;

namespace SkillShare.Application.CQRS.Chat.Commands.AddChatCommand
{
    public class AddChatCommand : IRequest<string>
    {
        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
        public AddChatCommand(Guid firstUserId, Guid secondUserId)
        {
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
        }
    }
}
