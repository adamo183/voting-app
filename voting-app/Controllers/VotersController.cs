using MediatR;
using Microsoft.AspNetCore.Mvc;
using voting_app_application_layer.Voters.GetAllVoters;
using voting_app_application_layer.Voters.InsertNewVoter;

namespace voting_app.Controllers
{
    [Route("[controller]")]
    public class VotersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VotersController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllVoters()
        {
            var voters = await _mediator.Send(new GetAllVotersQuery());
            return Ok(voters);
        }

        [HttpPost("")]
        public async Task<IActionResult> InsertNewVoter([FromBody] InsertNewVoterModel voterModel)
        {
            await _mediator.Send(new InsertNewVoterCommand(voterModel));
            return Created();
        }
    }
}
