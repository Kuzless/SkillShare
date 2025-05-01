using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.CQRS.User.Commands.CreateUserCommand;
using SkillShare.Application.DTOs;

namespace SkillShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] UserDTO user)
        {
            var command = new CreateUserCommand(user.Name, user.Email, user.Password, "tempToken", "tempToken");
            var result = await mediator.Send(command);
            if (!result)
            {
                return Conflict();
            }
            return Ok(result);
        }
    }
}
