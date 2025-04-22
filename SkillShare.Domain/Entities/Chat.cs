using Microsoft.EntityFrameworkCore;

namespace SkillShare.Domain.Entities
{
    [PrimaryKey(nameof(FirstUserId), nameof(SecondUserId))]
    public class Chat
    {
        public Guid FirstUserId { get; set; }
        public User FirstUser { get; set; }
        public Guid SecondUserId { get; set; }
        public User SecondUser { get; set; }
        public string LastMessage { get; set; }
        public Guid LastMessageOwner { get; set; }
        public bool IsNewMessagePresent { get; set; }
        public List<Message> Messages { get; set; }
    }
}
