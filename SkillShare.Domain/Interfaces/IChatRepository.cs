using SkillShare.Domain.Entities;

namespace SkillShare.Domain.Interfaces
{
    public interface IChatRepository : IGenericRepository<Chat>
    {
        public Task<Chat> Add(Chat item);
        Task<Chat> Delete(Guid id1, Guid id2);
        Task<List<Chat>> GetAll(Guid id);
    }
}
