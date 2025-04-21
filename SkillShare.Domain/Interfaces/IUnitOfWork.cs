namespace SkillShare.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITagRepository TagRepository { get; }
        IUserRepository UserRepository { get; }
        public Task SaveAsync();
    }
}
