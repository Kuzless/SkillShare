using SkillShare.Domain.Entities;

namespace SkillShare.Domain.Interfaces
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        public Task<double> GetAverageRating(Guid ownerId);
        public Task<List<double>> GetAllUserRatings(Guid ownerId);
    }
}
