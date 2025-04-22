using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;

namespace SkillShare.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DatabaseContext() : base()
        {
            
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Chat>().HasKey(k => new { k.FirstUserId, k.SecondUserId });
            modelBuilder.Entity<Chat>().HasOne(c => c.FirstUser).WithMany(u => u.Chats).HasForeignKey(c => c.FirstUserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Chat>().HasOne(c => c.SecondUser).WithMany().HasForeignKey(c => c.SecondUserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Message>().HasOne(m => m.Chat).WithMany(c => c.Messages).HasForeignKey(k => new { k.OwnerId, k.ReceiverId }).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
