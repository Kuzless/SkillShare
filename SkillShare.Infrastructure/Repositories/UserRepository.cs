using SkillShare.Domain.Interfaces;

namespace SkillShare.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
            
        }
    }
}
