using AutoMapper;
using MediatR;
using SkillShare.Application.DTOs;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Message.Queries.GetMessagesQuery
{
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, List<MessageDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetMessagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<MessageDTO>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MessageRepository.GetMessages(request.ChatFirstUser, request.ChatSecondUser);
            return _mapper.Map<List<MessageDTO>>(result);
        }
    }
}
