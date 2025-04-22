using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
