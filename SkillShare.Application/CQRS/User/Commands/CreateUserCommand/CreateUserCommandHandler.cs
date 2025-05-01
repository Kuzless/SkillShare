using AutoMapper;
using MediatR;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.User.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.Add(_mapper.Map<Domain.Entities.User>(request));
            await _unitOfWork.SaveAsync();
            return result != null; 
        }
    }
}
