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

        public async Task<bool> Delete(Guid id1, Guid id2)
        {
            var result = await context.Set<Chat>().Where(c => (c.FirstUserId == id1 && c.SecondUserId == id2) || (c.FirstUserId == id2 && c.SecondUserId == id1)).ExecuteDeleteAsync();
            return result > 0;
        }

        public async Task<List<Chat>> GetAll(Guid id)
        {
            return await context.Set<Chat>().Where(c => c.FirstUserId == id || c.SecondUserId == id).ToListAsync();
        }
        public async override Task<Chat> Add(Chat chat)
        {
            bool isExisting =  await context.Set<Chat>().AnyAsync(c =>
            (chat.FirstUserId == c.FirstUserId && chat.SecondUserId == c.SecondUserId) ||
            (chat.FirstUserId == c.SecondUserId && chat.SecondUserId == c.FirstUserId));
            if (isExisting)
            {
                return chat;
            }
            return await base.Add(chat);
        }
    }
}
