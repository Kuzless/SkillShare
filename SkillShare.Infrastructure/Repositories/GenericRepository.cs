using SkillShare.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SkillShare.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DatabaseContext context;
        public GenericRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public Task Add(T item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ValueType id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public Task<T> GetById(ValueType id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
