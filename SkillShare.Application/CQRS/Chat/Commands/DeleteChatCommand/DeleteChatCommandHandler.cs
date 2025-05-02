using MediatR;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Chat.Commands.DeleteChatCommand
{
    public class DeleteChatCommandHandler : IRequestHandler<DeleteChatCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteChatCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ChatRepository.Delete(request.FirstUserId, request.SecondUserId);
            if (entity != null)
            {
                await _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
