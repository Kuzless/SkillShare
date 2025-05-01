using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class ChatRepository : GenericRepository<Chat>, IChatRepository
    {
        public ChatRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<string> Add(Chat item)
        {
            await base.Add(item);
            var result = await context.Set<Chat>().FindAsync(item.FirstUserId, item.SecondUserId);
            return $"{result.FirstUserId}:{result.SecondUserId}";
        }
    }
}
