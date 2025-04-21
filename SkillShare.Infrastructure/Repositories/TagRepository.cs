using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class TagRepository : GenericRepository, ITagRepository
    {
        public TagRepository(DatabaseContext context) : base(context)
        {
            
        }
    }
}
