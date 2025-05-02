using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SkillShare.Application.CQRS.Chat.Commands.AddChatCommand;
using SkillShare.Application.CQRS.Chat.Commands.DeleteChatCommand;
using SkillShare.Application.CQRS.Chat.Queries.GetChatsByUserIdQuery;
using SkillShare.Application.DTOs;

namespace SkillShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMediator mediator;
        public ChatController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<ChatDTO>>> Get(Guid userId)
        {
            var result = await mediator.Send(new GetChatsByUserIdQuery(userId));
            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] ChatDTO chat)
        {
            var command = new AddChatCommand(chat.FirstUserId, chat.SecondUserId);
            var result = await mediator.Send(command);
            if (result.IsNullOrEmpty())
            {
                return Conflict();
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromBody] ChatDTO chat)
        {
            var command = new DeleteChatCommand(chat.FirstUserId, chat.SecondUserId);
            bool result = await mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
