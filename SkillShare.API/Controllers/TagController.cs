using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.CQRS.Tag.Commands.AddTagToUserCommand;
using SkillShare.Application.CQRS.Tag.Commands.CreateNewTagCommand;
using SkillShare.Application.CQRS.Tag.Commands.DeleteTagCommand;
using SkillShare.Application.CQRS.Tag.Commands.RemoveTagFromUserCommand;
using SkillShare.Application.CQRS.Tag.Queries.GetAllTagsQuery;
using SkillShare.Application.DTOs;

namespace SkillShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        public TagController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> CreateNewTag([FromBody] TagDTO tag)
        {
            var command = mapper.Map<CreateNewTagCommand>(tag);
            var result = await mediator.Send(command);
            if (!result)
            {
                return Conflict();
            }
            return Ok(true);
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTag([FromBody] TagDTO tag)
        {
            var command = mapper.Map<DeleteTagCommand>(tag);
            var result = await mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return Ok(true);
        }
        [HttpDelete]
        [Route("user")]
        public async Task<ActionResult<bool>> DeleteUserTag([FromBody] UserTagDTO tag)
        {
            var command = mapper.Map<RemoveTagFromUserCommand>(tag);
            var result = await mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<bool>> AddUserTag([FromBody] UserTagDTO tag)
        {
            var command = mapper.Map<AddTagToUserCommand>(tag);
            var result = await mediator.Send(command);
            if (!result)
            {
                return Conflict();
            }
            return Ok(true);
        }
        [HttpGet]
        public async Task<ActionResult<List<TagDTO>>> GetAllTags()
        {
            var query = new GetAllTagsQuery();
            var result = await mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
