namespace SkillShare.Application.DTOs.User
{
    public class UserDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public double? Rating { get; set; }
        public int? ReviewCount { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
