namespace SkillShare.Domain.Interfaces
{
    public interface IGenericRepository
    {
        public Task<T> GetById<T>(ValueType id);
        public Task<List<T>> GetAll<T>();
        public Task Add<T>(T item);
        public Task Update<T>(T item);
        public Task Delete(ValueType id);
    }
}
