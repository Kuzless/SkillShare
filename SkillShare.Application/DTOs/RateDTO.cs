namespace SkillShare.Application.DTOs
{
    public class RateDTO
    {
        public Guid OwnerId { get; set; }
        public Guid ReviewerId { get; set; }
        public double Mark { get; set; }
        public double? PreviousMark { get; set; }
    }
}
