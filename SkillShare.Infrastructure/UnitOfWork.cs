using SkillShare.Domain.Interfaces;
using SkillShare.Infrastructure.Repositories;

namespace SkillShare.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext context;
        public IUserRepository UserRepository { get; private set; }
        public ITagRepository TagRepository { get; private set; }

        public IChatRepository ChatRepository { get; private set; }

        public IMessageRepository MessageRepository { get; private set; }

        public IRatingRepository RatingRepository { get; private set; }

        public UnitOfWork(DatabaseContext context) 
        {
            this.context = context;
            UserRepository = new UserRepository(context);
            TagRepository = new TagRepository(context);
            ChatRepository = new ChatRepository(context);
            MessageRepository = new MessageRepository(context);
            RatingRepository = new RatingRepository(context);
        }

        public Task SaveAsync()
        {
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
