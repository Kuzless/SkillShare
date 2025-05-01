using MediatR;
using SkillShare.Infrastructure.DTOs;

namespace SkillShare.Application.CQRS.Chat.Queries.GetChatsByUserIdQuery
{
    public class GetChatsByUserIdQuery : IRequest<List<ChatDTO>>
    {
        public Guid UserId { get; set; }
        public GetChatsByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
