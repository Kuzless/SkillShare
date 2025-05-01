using AutoMapper;
using MediatR;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Chat.Commands.AddChatCommand
{
    public class AddChatCommandHandler : IRequestHandler<AddChatCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddChatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(AddChatCommand request, CancellationToken cancellationToken)
        {
            var chat = _mapper.Map<Domain.Entities.Chat>(request);
            var result = await _unitOfWork.ChatRepository.Add(chat);
            await _unitOfWork.SaveAsync();
            return result;
        }
    }
}
