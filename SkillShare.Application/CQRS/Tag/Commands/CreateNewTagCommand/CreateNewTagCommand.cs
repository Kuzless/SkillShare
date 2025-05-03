using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SkillShare.Application.CQRS.Tag.Commands.CreateNewTagCommand
{
    public class CreateNewTagCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public CreateNewTagCommand(string name)
        {
            Name = name;
        }
    }
}
