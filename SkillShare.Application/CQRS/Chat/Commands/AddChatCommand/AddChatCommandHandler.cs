using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Chat.Commands.AddChatCommand
{
    public class AddChatCommandHandler : IRequestHandler<AddChatCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AddChatCommandHandler> _logger;
        public AddChatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AddChatCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> Handle(AddChatCommand request, CancellationToken cancellationToken)
        {
            var chat = _mapper.Map<Domain.Entities.Chat>(request);
            try
            {
                var entity = await _unitOfWork.ChatRepository.GetChat(chat.FirstUserId, chat.SecondUserId);
                if (entity == null)
                {
                    var result = await _unitOfWork.ChatRepository.Add(chat);
                    await _unitOfWork.SaveAsync();
                    return $"{result.FirstUserId}:{result.SecondUserId}";
                }
                throw new InvalidOperationException("Object already exists");

            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding chat");
                return null;
            }
        }
    }
}
