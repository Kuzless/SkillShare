using AutoMapper;
using MediatR;
using SkillShare.Domain.Interfaces;
using SkillShare.Infrastructure.DTOs;

namespace SkillShare.Application.CQRS.Chat.Queries.GetChatsByUserIdQuery
{
    public class GetChatsByUserIdQueryHandler : IRequestHandler<GetChatsByUserIdQuery, List<ChatDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetChatsByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ChatDTO>> Handle(GetChatsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ChatRepository.GetAll(request.UserId);
            return _mapper.Map<List<ChatDTO>>(result);
        }
    }
}
