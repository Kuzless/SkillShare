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
    }
}
