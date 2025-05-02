using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(DatabaseContext context) : base(context)
        {

        }

        public Task<List<double>> GetAllUserRatings(Guid ownerId)
        {
            return context.Set<Rating>().Where(x => x.OwnerId == ownerId).Select(x => x.Mark).ToListAsync();
        }

        public Task<double> GetAverageRating(Guid ownerId)
        {
            var rating = context.Set<Rating>().Where(x => x.OwnerId == ownerId).Select(x => x.Mark).DefaultIfEmpty().AverageAsync();
            return rating;
        }
    }
}
