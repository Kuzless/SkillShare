namespace SkillShare.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> GetById(ValueType id);
        public Task Add(T item);
        public Task Update(T item);
    }
}
