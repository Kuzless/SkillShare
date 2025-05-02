namespace SkillShare.Application.DTOs
{
    public class ChatDTO
    {
        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
        public string? LastMessage { get; set; }
        public Guid? LastMessageOwner { get; set; }
        public bool? IsNewMessagePresent { get; set; }
    }
}
