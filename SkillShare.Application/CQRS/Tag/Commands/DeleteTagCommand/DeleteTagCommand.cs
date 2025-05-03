using MediatR;

namespace SkillShare.Application.CQRS.Tag.Commands.DeleteTagCommand
{
    public class DeleteTagCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeleteTagCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
