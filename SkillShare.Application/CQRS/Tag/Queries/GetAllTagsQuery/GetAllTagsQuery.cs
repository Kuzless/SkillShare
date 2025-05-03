using MediatR;
using SkillShare.Application.DTOs;

namespace SkillShare.Application.CQRS.Tag.Queries.GetAllTagsQuery
{
    public class GetAllTagsQuery : IRequest<List<TagDTO>> { }
}
