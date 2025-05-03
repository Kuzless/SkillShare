using MediatR;
using Microsoft.Extensions.Logging;
using SkillShare.Application.CQRS.Tag.Commands.AddTagToUserCommand;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Tag.Commands.RemoveTagFromUserCommand
{
    public class RemoveTagFromUserCommandHandler : IRequestHandler<RemoveTagFromUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddTagToUserCommandHandler> _logger;
        public RemoveTagFromUserCommandHandler(IUnitOfWork unitOfWork, ILogger<AddTagToUserCommandHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RemoveTagFromUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tag = await _unitOfWork.TagRepository.GetById(request.TagId);
                var user = await _unitOfWork.UserRepository.GetById(request.UserId);
                var initialAmount = user.Tags!.Count;
                user.Tags!.Remove(tag);
                var resultingAmount = user.Tags.Count;
                await _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.SaveAsync();
                return resultingAmount < initialAmount;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing tag from user");
                return false;
            }
        }
    }
}
