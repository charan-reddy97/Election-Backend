using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Entities;
using VotingLibrary.Entities;

namespace VotingApp.Repository
{
    public class VoteRepository:IVoteRepository
    {
        VotingDbContext dbContext;
        IUserRepository userRepository;
      

        public VoteRepository(VotingDbContext dbContext,IUserRepository userRepository)
        {
           
            this.userRepository = userRepository;
            this.dbContext = dbContext;

        }
        public Vote AddVote(Vote vote)
        {
            dbContext.Votes.Add(vote);
            dbContext.SaveChanges();
            return vote;
        }
       public Vote FindById(int id)
        {
            return dbContext.Votes.Include(d=>d.Candidate).FirstOrDefault(d => d.Voter.Id == id);
           // return dbContext.Votes.Distinct(d=>d.)
        }
       //public Candidate Count(Vote vote)
       // {
       //     var candidates=dbContext.Votes.
       //     //var res = dbContext.Votes.Count(d => d.Candidate.Id == candidate.Id);
       //     var count = dbContext.Votes.Select(d => d.Candidate.Id == vote.Candidate.Id).Count();
       //     //var dis=dbContext.Votes.Distinct(vote.Candidate.Id).
       //     //return count;
       // }
    }
}
