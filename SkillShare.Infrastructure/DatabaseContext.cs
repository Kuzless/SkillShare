using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;

namespace SkillShare.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users = null!;
        public DbSet<Tag> Tags = null!;
        public DatabaseContext() : base()
        {
            
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
