using AutoMapper;
using MediatR;
using SkillShare.Application.DTOs;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Tag.Queries.GetAllTagsQuery
{
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, List<TagDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllTagsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<TagDTO>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _unitOfWork.TagRepository.GetAllTags();
            var tagDTOs = _mapper.Map<List<TagDTO>>(tags);
            return tagDTOs;
        }
    }
}
