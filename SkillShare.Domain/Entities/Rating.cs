using Microsoft.EntityFrameworkCore;

namespace SkillShare.Domain.Entities
{
    [PrimaryKey(nameof(OwnerId), nameof(ReviewerId))]
    public class Rating
    {
        public Guid OwnerId { get; set; }
        public Guid ReviewerId { get; set; }
        public double Mark { get; set; }
    }
}
