using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.CQRS.Message.Commands.SendMessageCommand;
using SkillShare.Application.CQRS.Message.Queries.GetMessagesQuery;
using SkillShare.Application.DTOs;

namespace SkillShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public MessageController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDTO message)
        {
            var command = mapper.Map<SendMessageCommand>(message);
            var result = await mediator.Send(command);
            if (!result)
            {
                return Conflict();
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<MessageDTO>>> GetMessages([FromQuery] Guid chatFirstUser, [FromQuery] Guid chatSecondUser)
        {
            var query = new GetMessagesQuery(chatFirstUser, chatSecondUser);
            var result = await mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
