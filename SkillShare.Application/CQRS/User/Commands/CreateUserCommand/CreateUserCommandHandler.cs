using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.User.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserCommandHandler> _logger;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateUserCommandHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.UserRepository.Add(_mapper.Map<Domain.Entities.User>(request));
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user");
                return false;
            }
        }
    }
}
