using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app_application_layer.Candidates.InsertCandidate;
using voting_app_domain_layer.Interfaces;
using voting_app_domain_layer.Models;

namespace voting_app_application_layer.Vote.VoteForCandidate
{
    public class AddVoteForCandidateCommandHandler : IRequestHandler<AddVoteForCandidateCommand>
    {
        private IVoterRepository _voterRepository;
        public AddVoteForCandidateCommandHandler(IVoterRepository voterRepository) 
        { 
            _voterRepository = voterRepository;
        }

        public async Task Handle(AddVoteForCandidateCommand request, CancellationToken cancellationToken)
        {
            var voter = await _voterRepository.GetVoterById(request.AddVoteModel.VoterId);
            if (voter != null)
            {
                voter.CandidateId = request.AddVoteModel.CandidateId;
                await _voterRepository.UpdateVoter(voter);
            }
        }
    }
}
