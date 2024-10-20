using MediatR;
using Microsoft.AspNetCore.Mvc;
using voting_app_application_layer.Vote.VoteForCandidate;
using voting_app_application_layer.Voters.InsertNewVoter;

namespace voting_app.Controllers
{
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("")]
        public async Task<IActionResult> AddVote([FromBody] AddVoteDto voterModel)
        {
            await _mediator.Send(new AddVoteForCandidateCommand(voterModel));
            return Ok();
        }
    }
}
