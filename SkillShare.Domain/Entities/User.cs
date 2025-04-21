using System.ComponentModel.DataAnnotations;

namespace SkillShare.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
