using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.CQRS.User.Commands.CreateUserCommand;
using SkillShare.Application.CQRS.User.Commands.LoginUserCommand;
using SkillShare.Application.CQRS.User.Commands.UpdateUserInfoCommand;
using SkillShare.Application.CQRS.User.Queries.GetPropositionsQuery;
using SkillShare.Application.DTOs;
using SkillShare.Application.DTOs.User;

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
        [Route("register")]
        public async Task<ActionResult<TokensDTO>> Register([FromBody] AuthUserDTO user)
        {
            var command = mapper.Map<CreateUserCommand>(user);
            var result = await mediator.Send(command);
            if (result == null)
            {
                return Conflict();
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokensDTO>> Login([FromBody] AuthUserDTO user)
        {
            var command = mapper.Map<LoginUserCommand>(user);
            var result = await mediator.Send(command);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateUserData([FromBody] UserDTO user)
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
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserPropositionsDTO>>> GetPropositions(Guid id)
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
