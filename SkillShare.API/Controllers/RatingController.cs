using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.CQRS.Rating.Commands.AddRatingReviewCommand;
using SkillShare.Application.CQRS.Rating.Commands.ChangeRatingReviewCommand;
using SkillShare.Application.DTOs;

namespace SkillShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public RatingController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] RateDTO rate)
        {
            var command = mapper.Map<AddRatingReviewCommand>(rate);
            var result = await mediator.Send(command);
            if (!result)
            {
                return Conflict();
            }
            return Ok(true);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] RateDTO rate)
        {
            var command = mapper.Map<ChangeRatingReviewCommand>(rate);
            var result = await mediator.Send(command);
            if (!result)
            {
                return Conflict();
            }
            return Ok(true);
        }
    }
}
