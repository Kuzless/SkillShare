using System;
using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class ChatRepository : GenericRepository<Chat>, IChatRepository
    {
        public ChatRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Chat> Delete(Guid id1, Guid id2)
        {
            var entity = await context.Set<Chat>().Where(c => (c.FirstUserId == id1 && c.SecondUserId == id2) || (c.FirstUserId == id2 && c.SecondUserId == id1)).FirstOrDefaultAsync();
            var result = context.Set<Chat>().Remove(entity!);
            return entity!;
        }

        public async Task<List<Chat>> GetAll(Guid id)
        {
            return await context.Set<Chat>().Where(c => c.FirstUserId == id || c.SecondUserId == id).ToListAsync();
        }
        public async Task<Chat?> GetChat(Guid firstId, Guid secondId)
        {
            return await context.Set<Chat>().Where(c =>
            (firstId == c.FirstUserId && secondId == c.SecondUserId) ||
            (firstId == c.SecondUserId && secondId == c.FirstUserId)).FirstOrDefaultAsync();
        }
    }
}
