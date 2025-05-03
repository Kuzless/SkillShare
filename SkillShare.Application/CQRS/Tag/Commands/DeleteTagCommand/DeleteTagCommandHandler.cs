using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Tag.Commands.DeleteTagCommand
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteTagCommandHandler> _logger;
        private readonly IMapper _mapper;
        public DeleteTagCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteTagCommandHandler> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.TagRepository.Delete(_mapper.Map<Domain.Entities.Tag>(request));
                var result = await _unitOfWork.SaveAsync();
                return result > 0;
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting tag");
                return false;
            }
        }
    }
}
