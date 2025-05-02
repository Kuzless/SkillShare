using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.CQRS.User.Commands.CreateUserCommand;
using SkillShare.Application.CQRS.User.Commands.UpdateUserInfoCommand;
using SkillShare.Application.CQRS.User.Queries.GetPropositionsQuery;
using SkillShare.Application.DTOs;

namespace SkillShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public UserController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] UserDTO user)
        {
            var command = mapper.Map<CreateUserCommand>(user);
            command.RefreshToken = "string";
            command.Token = "string";
            var result = await mediator.Send(command);
            if (!result)
            {
                return Conflict();
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] UserDTO user)
        {
            var command = mapper.Map<UpdateUserInfoCommand>(user);
            command.RefreshToken = "string";
            command.Token = "string";
            var result = await mediator.Send(command);
            if (!result)
            {
                return Conflict();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserPropositionsDTO>>> Get(Guid id)
        {
            var result = await mediator.Send(new GetPropositionsQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
