using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(DatabaseContext context) : base(context)
        {
            
        }

        public async Task<Tag> Delete(Tag tag)
        {
            var entity = await context.Set<Tag>().Where(t => t.Id == tag.Id || t.Name == tag.Name).FirstOrDefaultAsync();
            var result = context.Set<Tag>().Remove(entity!);
            return entity!;
        }

        public async Task<List<Tag>> GetAllTags()
        {
            return await context.Set<Tag>().ToListAsync();
        }

        public async Task<Tag> GetById(int id)
        {
            Tag? entity = await context.Set<Tag>().Where(t => t.Id == id).FirstOrDefaultAsync();
            return entity!;
        }
    }
}
