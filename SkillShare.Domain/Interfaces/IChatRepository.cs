using SkillShare.Domain.Entities;

namespace SkillShare.Domain.Interfaces
{
    public interface IChatRepository : IGenericRepository<Chat>
    {
        new Task<Chat> Add(Chat item);
        Task<Chat> Delete(Guid id1, Guid id2);
        Task<List<Chat>> GetAll(Guid id);
        Task<Chat?> GetChat(Guid firstId, Guid secondId);
    }
}
