using MediatR;
using Microsoft.AspNetCore.Mvc;
using voting_app_application_layer.Voters.GetAllVoters;

namespace voting_app.Controllers
{
    public class VotersController : ControllerBase
    {
        public VotersController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        [HttpGet("all")]
        public async Task<IActionResult> GetAllVoters()
        {
            var voters = await _mediator.Send(new GetAllVotersQuery());
            return Ok(voters);
        }
    }
}
