namespace SkillShare.Application.DTOs
{
    public class MessageDTO
    {
        public string Name { get; set; }
        public Guid ChatFirstUser { get; set; }
        public Guid ChatSecondUser { get; set; }
        public string Text { get; set; }
    }
}
