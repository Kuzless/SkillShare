using MediatR;
using SkillShare.Application.DTOs;

namespace SkillShare.Application.CQRS.User.Queries.GetPropositionsQuery
{
    public class GetPropositionsQuery : IRequest<List<UserPropositionsDTO>>
    {
        public Guid UserId { get; set; }
        public GetPropositionsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
