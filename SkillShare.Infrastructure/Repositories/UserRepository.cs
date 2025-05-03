using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
            
        }

        public async Task<List<User>> GetPropositions(Guid userId)
        {
            return await context.Set<User>().Where(u => u.Id != userId).ToListAsync();
        }
        public async Task<User> GetById(Guid id)
        {
            return await context.Set<User>()
                .Include(u => u.Tags)
                .FirstAsync(u => u.Id == id);
        }
    }
}
