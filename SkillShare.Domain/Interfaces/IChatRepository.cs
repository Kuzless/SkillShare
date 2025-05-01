using SkillShare.Domain.Entities;

namespace SkillShare.Domain.Interfaces
{
    public interface IChatRepository : IGenericRepository<Chat>
    {
        new Task<string> Add(Chat item);
        new Task<bool> Delete(Guid id1, Guid id2);
    }
}
