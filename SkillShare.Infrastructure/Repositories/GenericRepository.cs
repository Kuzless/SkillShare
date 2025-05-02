using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DatabaseContext context;
        public GenericRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public async virtual Task<T> Add(T item)
        {
            var entity = await context.Set<T>().AddAsync(item);
            return entity.Entity;
        }

        public virtual Task<T> GetById(ValueType id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Update(T item)
        {
            var entity = context.Set<T>().Update(item);
            return entity.Entity;
        }
    }
}
