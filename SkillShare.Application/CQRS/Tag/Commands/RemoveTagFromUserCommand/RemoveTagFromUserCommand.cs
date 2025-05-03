using MediatR;

namespace SkillShare.Application.CQRS.Tag.Commands.RemoveTagFromUserCommand
{
    public class RemoveTagFromUserCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public int TagId { get; set; }
        public RemoveTagFromUserCommand(Guid userid, int tagid)
        {
            UserId = userid;
            TagId = tagid;
        }
    }
}
