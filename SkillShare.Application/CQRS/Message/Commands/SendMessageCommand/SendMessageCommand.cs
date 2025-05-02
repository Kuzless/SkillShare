using MediatR;

namespace SkillShare.Application.CQRS.Message.Commands.SendMessageCommand
{
    public class SendMessageCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid ChatFirstUser { get; set; }
        public Guid ChatSecondUser { get; set; }
        public string Text { get; set; }
        public SendMessageCommand(Guid userId, Guid chatFirstUser, Guid chatSecondUser, string text)
        {
            ChatFirstUser = chatFirstUser;
            ChatSecondUser = chatSecondUser;
            Text = text;
            UserId = userId;
        }
    }
}
