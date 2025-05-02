using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Rating.Commands.ChangeRatingReviewCommand
{
    public class ChangeRatingReviewCommandHandler : IRequestHandler<ChangeRatingReviewCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ChangeRatingReviewCommandHandler> _logger;
        public ChangeRatingReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ChangeRatingReviewCommandHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(ChangeRatingReviewCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.RatingRepository.Update(_mapper.Map<Domain.Entities.Rating>(request));
                var user = await _unitOfWork.UserRepository.GetById(request.OwnerId);
                var ratingList = await _unitOfWork.RatingRepository.GetAllUserRatings(request.OwnerId);
                double rating = 0;
                int ratingCount = 0;
                foreach (var r in ratingList)
                {
                    rating += r;
                    ratingCount++;
                }
                rating -= request.PreviousMark;
                rating += request.Mark;
                user.Rating = Math.Round(rating / ratingCount, 1);
                user.ReviewCount = ratingCount;
                await _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding rating review");
                return false;
            }
        }
    }
}
