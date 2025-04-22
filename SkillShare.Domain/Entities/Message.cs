namespace SkillShare.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Guid OwnerId { get; set; }
        public Guid ReceiverId { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public User Owner { get; set; }
    }
}
