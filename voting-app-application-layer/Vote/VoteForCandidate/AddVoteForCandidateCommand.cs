using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voting_app_application_layer.Vote.VoteForCandidate
{
    public class AddVoteForCandidateCommand : IRequest
    {
        public AddVoteDto AddVoteModel { get; set; }
        public AddVoteForCandidateCommand(AddVoteDto addVoteModel)
        {
            AddVoteModel = addVoteModel;
        }
    }
}
