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
        public virtual Task Add(T item)
        {
            context.Set<T>().AddAsync(item);
            return Task.CompletedTask;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual Task<T> GetById(ValueType id)
        {
            throw new NotImplementedException();
        }

        public virtual Task Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
