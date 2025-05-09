﻿using MediatR;

namespace SkillShare.Application.CQRS.Chat.Commands.DeleteChatCommand
{
    public class DeleteChatCommand : IRequest<bool>
    {
        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
        public DeleteChatCommand(Guid firstUserId, Guid secondUserId)
        {
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
        }
    }
}
