using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace VotingApp.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        VotingDbContext dbContext;
        public CandidateRepository(VotingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Candidate AddCandidate(Candidate candidate)
        {
            candidate.CreatedDate = DateTime.Now;
            dbContext.Candidates.Add(candidate);
            dbContext.SaveChanges();
            return candidate;
        }

        public void DeleteCandidate(int userid)
        {
            Candidate currentCandidate = dbContext.Candidates.FirstOrDefault(d => d.Id == userid);
            if (currentCandidate != null)
            {
                currentCandidate.DeletedDate = DateTime.Now;
                dbContext.Candidates.Update(currentCandidate);
                dbContext.SaveChanges();

            }
        }

        public Candidate FindByCandidateName(string username, string password)
        {
            return dbContext.Candidates.FirstOrDefault(d => d.Email == username
                                                   && d.Password == password
                                                   && d.DeletedDate == null);
        }

        public List<Candidate> GetCandidates()
        {
            return dbContext.Candidates.Where(d => d.DeletedDate == null).ToList();
        }

        public Candidate UpdateCandidate(Candidate candidate)
        {
            Candidate currentCandidate = dbContext.Candidates.FirstOrDefault(d => d.Id == candidate.Id);
            if (currentCandidate != null)
            {
                currentCandidate.FirstName = candidate.FirstName;
                currentCandidate.LastName = candidate.LastName;
                currentCandidate.Email = candidate.Email;
                currentCandidate.Password = candidate.Password;
                //currentCandidate.Role = candidate.Role;
                currentCandidate.Gender = candidate.Gender;
                currentCandidate.Aadhar = candidate.Aadhar;


                dbContext.Candidates.Update(currentCandidate);
                dbContext.SaveChanges();

            }

            return candidate;
        }
        public Candidate FindCandidateById(int id)
        {
            return dbContext.Candidates.FirstOrDefault(d => d.Id == id);
        }
    }
}
