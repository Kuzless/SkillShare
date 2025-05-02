namespace SkillShare.Domain.Entities
{
    public class Rating
    {
        public Guid OwnerId { get; set; }
        public Guid ReviewerId { get; set; }
        public double Mark { get; set; }
        public User Owner { get; set; }
        public User Reviewer { get; set; }
    }
}
