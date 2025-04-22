using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class ChatRepository : GenericRepository<Chat>, IChatRepository
    {
        public ChatRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
