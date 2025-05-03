using SkillShare.Domain.Entities;

namespace SkillShare.Domain.Interfaces
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Task<Tag> GetById(int id);
        Task<Tag> Delete(Tag tag);
        Task<List<Tag>> GetAllTags();
    }
}
