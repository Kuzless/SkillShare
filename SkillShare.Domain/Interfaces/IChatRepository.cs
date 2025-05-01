using SkillShare.Domain.Entities;

namespace SkillShare.Domain.Interfaces
{
    public interface IChatRepository : IGenericRepository<Chat>
    {
        new Task<string> Add(Chat item);
    }
}
