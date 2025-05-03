using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Tag.Commands.CreateNewTagCommand
{
    public class CreateNewTagCommandHandler : IRequestHandler<CreateNewTagCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateNewTagCommandHandler> _logger;
        private readonly IMapper _mapper;
        public CreateNewTagCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateNewTagCommandHandler> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateNewTagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.TagRepository.Add(_mapper.Map<Domain.Entities.Tag>(request));
                var result = await _unitOfWork.SaveAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new tag");
                return false;
            }
        }
    }
}
