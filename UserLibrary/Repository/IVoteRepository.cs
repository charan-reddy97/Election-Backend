using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingLibrary.Entities;

namespace UserLibrary.Repository
{
    public interface IVoteRepository
    {
        Vote AddVote(Vote vote);
        Vote FindById(int Id);
    }
}
