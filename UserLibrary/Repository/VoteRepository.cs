using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp;
using VotingApp.Repository;
using VotingLibrary.Entities;

namespace UserLibrary.Repository
{
    public class VoteRepository:IVoteRepository
    {
       
            VotingDbContext dbContext;
            IUserRepository userRepository;


            public VoteRepository(VotingDbContext dbContext, IUserRepository userRepository)
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
                return dbContext.Votes.Include(d => d.Candidate).FirstOrDefault(d => d.Voter.Id == id);
                
            }
        }
}
