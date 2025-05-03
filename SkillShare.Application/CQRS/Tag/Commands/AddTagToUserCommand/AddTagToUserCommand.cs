using MediatR;

namespace SkillShare.Application.CQRS.Tag.Commands.AddTagToUserCommand
{
    public class AddTagToUserCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public int TagId { get; set; }
        public AddTagToUserCommand(Guid userId, int tagId)
        {
            UserId = userId;
            TagId = tagId;
        }
    }
}
