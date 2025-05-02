using MediatR;

namespace SkillShare.Application.CQRS.Rating.Commands.ChangeRatingReviewCommand
{
    public class ChangeRatingReviewCommand : IRequest<bool>
    {
        public Guid OwnerId { get; set; }
        public Guid ReviewerId { get; set; }
        public double Mark { get; set; }
        public double PreviousMark { get; set; }
        public ChangeRatingReviewCommand(Guid ownerId, Guid reviewerId, double mark, double previousMark)
        {
            OwnerId = ownerId;
            ReviewerId = reviewerId;
            Mark = mark;
            PreviousMark = previousMark;
        }
    }
}
