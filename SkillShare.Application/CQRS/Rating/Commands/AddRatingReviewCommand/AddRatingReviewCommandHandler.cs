using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.Rating.Commands.AddRatingReviewCommand
{
    public class AddRatingReviewCommandHandler : IRequestHandler<AddRatingReviewCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AddRatingReviewCommandHandler> _logger;
        public AddRatingReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AddRatingReviewCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(AddRatingReviewCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mark = await _unitOfWork.RatingRepository.Add(_mapper.Map<Domain.Entities.Rating>(request));
                var user = await _unitOfWork.UserRepository.GetById(request.OwnerId);
                var ratingList = await _unitOfWork.RatingRepository.GetAllUserRatings(request.OwnerId);
                double rating = 0;
                int ratingCount = 0;
                ratingList.Add(mark.Mark);
                foreach(var r in ratingList)
                {
                    rating += r;
                    ratingCount++;
                }
                user.Rating = Math.Round(rating / ratingCount, 1);
                user.ReviewCount = ratingCount;
                await _unitOfWork.UserRepository.Update(user);
                var result = await _unitOfWork.SaveAsync();
                return result > 0;
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding rating review");
                return false;
            }
        }
    }
}
