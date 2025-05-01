using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.CQRS.Chat.Commands.AddChatCommand;
using SkillShare.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ITestInterface TestService { get; set; }
        private IMediator mediator;
        public ValuesController(ITestInterface test, IMediator mediator)
        {
            TestService = test;
            this.mediator = mediator;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            TestService.Test();
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Task<string> PostChat([FromBody] AddChatCommand chat)
        {
            return mediator.Send(chat);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
