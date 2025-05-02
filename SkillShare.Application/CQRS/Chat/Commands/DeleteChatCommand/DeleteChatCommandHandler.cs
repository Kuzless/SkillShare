using MediatR;
using Microsoft.Extensions.Logging;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Chat.Commands.DeleteChatCommand
{
    public class DeleteChatCommandHandler : IRequestHandler<DeleteChatCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteChatCommandHandler> _logger;
        public DeleteChatCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteChatCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<bool> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.ChatRepository.Delete(request.FirstUserId, request.SecondUserId);
                await _unitOfWork.SaveAsync();
                return true;
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting chat");
                return false;
            }   
        }
    }
}
