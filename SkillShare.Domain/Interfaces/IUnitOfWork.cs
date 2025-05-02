namespace SkillShare.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITagRepository TagRepository { get; }
        IUserRepository UserRepository { get; }
        IChatRepository ChatRepository { get; }
        IMessageRepository MessageRepository { get; }
        IRatingRepository RatingRepository { get; }
        public Task<int> SaveAsync();
    }
}
