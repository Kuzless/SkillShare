using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        protected DatabaseContext context;
        public GenericRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public Task Add<T>(T item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ValueType id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById<T>(ValueType id)
        {
            throw new NotImplementedException();
        }

        public Task Update<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}
