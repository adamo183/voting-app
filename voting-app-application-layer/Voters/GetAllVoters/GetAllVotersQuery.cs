﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voting_app_application_layer.Voters.GetAllVoters
{
    public class GetAllVotersQuery : IRequest<List<VoterDto>>
    {
    }
}
