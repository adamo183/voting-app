using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app_application_layer.Voters.InsertNewVoter;
using voting_app_domain_layer.Interfaces;
using voting_app_domain_layer.Models;

namespace voting_app_application_layer.Candidates.InsertCandidate
{
    public class InsertNewCandidateCommandHandler : IRequestHandler<InsertNewCandidateCommand>
    {
        private readonly ICandidateRepository _candidateRepository;
        public InsertNewCandidateCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task Handle(InsertNewCandidateCommand request, CancellationToken cancellationToken)
        {
            var modelToInsert = new Candidate()
            {
                Name = request.Model.Name,
            };

            await _candidateRepository.InsertNewCandidate(modelToInsert);
        }
    }
}
