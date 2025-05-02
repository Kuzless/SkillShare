using MediatR;
using SkillShare.Application.DTOs;

namespace SkillShare.Application.CQRS.Message.Queries.GetMessagesQuery
{
    public class GetMessagesQuery : IRequest<List<MessageDTO>>
    {
        public Guid ChatFirstUser { get; set; }
        public Guid ChatSecondUser { get; set; }
        public GetMessagesQuery(Guid chatFirstUser, Guid chatSecondUser)
        {
            ChatFirstUser = chatFirstUser;
            ChatSecondUser = chatSecondUser;
        }
    }
}
