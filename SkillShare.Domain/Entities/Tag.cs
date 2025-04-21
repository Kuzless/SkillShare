namespace SkillShare.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
