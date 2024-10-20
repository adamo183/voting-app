using MediatR;
using Microsoft.AspNetCore.Mvc;
using voting_app_application_layer.Candidates.GetAllCandidates;
using voting_app_application_layer.Candidates.InsertCandidate;
using voting_app_application_layer.Voters.GetAllVoters;
using voting_app_application_layer.Voters.InsertNewVoter;

namespace voting_app.Controllers
{
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCandidates()
        {
            var voters = await _mediator.Send(new GetAllCandidatesQuery());
            return Ok(voters);
        }

        [HttpPost("")]
        public async Task<IActionResult> InsertNewVoter([FromBody] InsertCandidateModel voterModel)
        {
            await _mediator.Send(new InsertNewCandidateCommand(voterModel));
            return Created();
        }



    }
}
