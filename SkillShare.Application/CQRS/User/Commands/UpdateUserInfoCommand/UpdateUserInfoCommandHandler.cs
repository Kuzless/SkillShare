using AutoMapper;
using MediatR;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.User.Commands.UpdateUserInfoCommand
{
    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UpdateUserInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.UserRepository.Update(mapper.Map<Domain.Entities.User>(request));
            var result = await unitOfWork.SaveAsync();
            return true;
        }
    }
}
