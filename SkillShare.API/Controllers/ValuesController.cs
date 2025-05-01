using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.CQRS.Chat.Commands.AddChatCommand;
using SkillShare.Application.CQRS.Chat.Commands.DeleteChatCommand;
using SkillShare.Application.CQRS.Chat.Queries.GetChatsByUserIdQuery;
using SkillShare.Infrastructure.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IMediator mediator;
        public ValuesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<List<ChatDTO>> Get(Guid userId)
        {
            return await mediator.Send(new GetChatsByUserIdQuery(userId));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<string> PostChat([FromBody] AddChatCommand chat)
        {
            return await mediator.Send(chat);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromBody] DeleteChatCommand chat)
        {
            bool result = await mediator.Send(chat);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
