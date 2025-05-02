namespace SkillShare.Application.DTOs
{
    public class SendMessageDTO
    {
        public Guid UserId { get; set; }
        public Guid ChatFirstUser { get; set; }
        public Guid ChatSecondUser { get; set; }
        public string Text { get; set; }
    }
}
