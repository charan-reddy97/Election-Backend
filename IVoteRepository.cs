using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Entities;
using VotingLibrary.Entities;

namespace VotingApp.Repository
{
    public interface IVoteRepository
    {
        Vote AddVote(Vote vote);
        Vote FindById(int  Id);
        //int Count(Vote candidate);
    }
}
