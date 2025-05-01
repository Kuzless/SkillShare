namespace SkillShare.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> GetById(ValueType id);
        public Task<List<T>> GetAll();
        public Task Add(T item);
        public Task Update(T item);
    }
}
