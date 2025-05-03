using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Tag.Commands.AddTagToUserCommand
{
    public class AddTagToUserCommandHandler : IRequestHandler<AddTagToUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddTagToUserCommandHandler> _logger;
        public AddTagToUserCommandHandler(IUnitOfWork unitOfWork, ILogger<AddTagToUserCommandHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddTagToUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tag = await _unitOfWork.TagRepository.GetById(request.TagId);
                var user = await _unitOfWork.UserRepository.GetById(request.UserId);
                if (user.Tags.IsNullOrEmpty())
                {
                    user.Tags = new List<Domain.Entities.Tag>();
                }
                user.Tags!.Add(tag);
                await _unitOfWork.UserRepository.Update(user);
                var result = await _unitOfWork.SaveAsync();
                return result > 0;
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding tag to user");
                return false;
            }
        }
    }
}
