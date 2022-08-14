using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Controllers;
using VotingApp.Repository;
using VotingLibrary.Entities;
using VotingLibrary.Repository;

namespace UserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVoteController : ControllerBase
    {

        ICandidateRepository candidateRepository;
        IVoteRepository voteRepository;
        IELectionRepository electionRepository;
        IUserRepository userRepository;

        public UserVoteController(ICandidateRepository candidateRepository, IVoteRepository voteRepository, IELectionRepository electionRepository, IUserRepository userRepository)
        {
            this.candidateRepository = candidateRepository;
            this.voteRepository = voteRepository;
            this.electionRepository = electionRepository;
            this.userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Post(VoteModel vote)
        {
            var candidate = candidateRepository.FindCandidateById(vote.CandidateId);
            var voter = userRepository.FindById(vote.VoterId);
            var election = electionRepository.FindElectionById(vote.ElectionId);

            var v = new Vote { Candidate = candidate, Election = election, Voter = voter };
            var id = voteRepository.FindById(voter.Id);
            if (id == null)
            {
                var registeredVote = voteRepository.AddVote(v);
                return Created($"/api/vote/{registeredVote.VoteId}", vote);
            }
            else
            {
                return BadRequest("You have already casted your vote");
            }

        }
        [HttpGet("byid/{id}")]
        public IActionResult Get(int id)
        {
            var voter = voteRepository.FindById(id);
            return Ok(voter);
        }
    }
}
