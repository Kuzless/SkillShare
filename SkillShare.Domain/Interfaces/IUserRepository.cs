using SkillShare.Domain.Entities;

namespace SkillShare.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<List<User>> GetPropositions(Guid userId);
        public Task<User> GetById(Guid id);
    }
}
