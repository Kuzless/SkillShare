using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.User.Commands.UpdateUserInfoCommand
{
    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<UpdateUserInfoCommandHandler> logger;
        public UpdateUserInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateUserInfoCommandHandler> logger)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        public async Task<bool> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await unitOfWork.UserRepository.Update(mapper.Map<Domain.Entities.User>(request));
                var result = await unitOfWork.SaveAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating user");
                return false;
            }
        }
    }
}
