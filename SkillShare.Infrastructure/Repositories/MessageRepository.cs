using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<Message>> GetMessages(Guid fUserId, Guid sUserId)
        {
            return await context.Set<Message>()
                .Where(m => m.ChatFirstUser == fUserId && m.ChatSecondUser == sUserId)
                .Include(c => c.User)
                .ToListAsync();
        }
    }
}
