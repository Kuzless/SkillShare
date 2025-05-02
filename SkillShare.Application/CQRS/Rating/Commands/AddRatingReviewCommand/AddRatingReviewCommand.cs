using MediatR;

namespace SkillShare.Application.CQRS.Rating.Commands.AddRatingReviewCommand
{
    public class AddRatingReviewCommand : IRequest<bool>
    {
        public Guid OwnerId { get; set; }
        public Guid ReviewerId { get; set; }
        public double Mark { get; set; }
        public AddRatingReviewCommand(Guid ownerId, Guid reviewerId, double mark)
        {
            OwnerId = ownerId;
            ReviewerId = reviewerId;
            Mark = mark;
        }
    }
}
