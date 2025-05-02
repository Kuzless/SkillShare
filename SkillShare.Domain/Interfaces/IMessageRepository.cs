using SkillShare.Domain.Entities;

namespace SkillShare.Domain.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<List<Message>> GetMessages(Guid fUserId, Guid sUserId);
    }
}
