using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Message.Commands.SendMessageCommand
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SendMessageCommandHandler> _logger;
        private readonly IMapper _mapper;
        public SendMessageCommandHandler(IUnitOfWork unitOfWork, ILogger<SendMessageCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.MessageRepository.Add(_mapper.Map<Domain.Entities.Message>(request));
                var entity = await _unitOfWork.ChatRepository.GetChat(request.ChatFirstUser, request.ChatSecondUser);
                entity!.LastMessageOwner = request.UserId;
                entity.LastMessage = request.Text;
                entity.IsNewMessagePresent = true;
                await _unitOfWork.ChatRepository.Update(entity);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while sending message");
                return false;
            }
        }
    }
}
