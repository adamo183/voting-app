using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app_domain_layer.Interfaces;
using voting_app_domain_layer.Models;

namespace voting_app_application_layer.Voters.InsertNewVoter
{
    public class InsertNewVoterCommandHandler : IRequestHandler<InsertNewVoterCommand>
    {
        private readonly IVoterRepository _voterRepository;
        public InsertNewVoterCommandHandler(IVoterRepository voterRepository)
        {
            _voterRepository = voterRepository;
        }

        public async Task Handle(InsertNewVoterCommand request, CancellationToken cancellationToken)
        {
            var modelToInsert = new Voter()
            {
                 Name = request.Model.Name,
                 CandidateId = null,
            };

            await _voterRepository.InsertNewVoter(modelToInsert);
        }
    }
}
