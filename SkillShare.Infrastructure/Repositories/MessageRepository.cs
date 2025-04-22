using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
