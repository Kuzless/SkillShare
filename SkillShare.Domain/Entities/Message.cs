namespace SkillShare.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Guid ChatFirstUser { get; set; }
        public Guid ChatSecondUser { get; set; }
        public Guid UserId { get; set; }
        public Chat Chat { get; set; }
        public User User { get; set; }
    }
}
