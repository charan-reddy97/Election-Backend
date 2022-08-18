using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace VotingApp.Repository
{
    public interface ICandidateRepository
    {
        Candidate AddCandidate(Candidate candidate);
        void DeleteCandidate(int id);
        Candidate FindByCandidateName(string username, string password);
        List<Candidate> GetCandidates();
        Candidate UpdateCandidate(Candidate candidate);
        Candidate FindCandidateById(int id);
    }
}
