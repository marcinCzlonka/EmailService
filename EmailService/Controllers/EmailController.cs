using System.Threading.Tasks;
using EmailService.Common.DataClasses;
using EmailService.Database.Queries.Emails;
using EmailService.Database.Requests.Emails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : BaseController
    {
        // GET api/<EmailController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetEmailDetailsQuery(){ Id = id}));
        }

        // GET api/<EmailController>/5
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllEmailsQuery()));
        }

        // POST api/<EmailController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("/[action]")]
        public async Task<IActionResult> Create([FromBody] CreateEmailRequest command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        // PUT api/<EmailController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("/[action]")]
        public async Task<IActionResult> Send([FromBody] SendPendingEmailsRequest command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}