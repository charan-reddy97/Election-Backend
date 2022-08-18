using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp;
using VotingLibrary.Entities;

namespace VotingLibrary.Repository
{
    public class ElectionRepository : IELectionRepository
    {
        VotingDbContext DbContext;
        public ElectionRepository(VotingDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public Election AddElection(Election election)
        {
            election.CreatedDate = DateTime.Now;
            DbContext.Elections.Add(election);
            DbContext.SaveChanges();
            return election;
        }

        public void DeleteElection(int Id)
        {
            Election currentelection = DbContext.Elections.FirstOrDefault(d => d.Pollnumber == Id);
            if (currentelection != null)
            {
                currentelection.DeletedDate = DateTime.Now;
                DbContext.Elections.Update(currentelection);
                DbContext.SaveChanges();

            }
        }

        public Election FindElectionByName(string name)
        {
            return DbContext.Elections.FirstOrDefault(d => d.Position == name);
        }

        public Election UpdateElection(Election election)
        {
            Election currentelection = DbContext.Elections.FirstOrDefault(d => d.Pollnumber == election.Pollnumber);
            if (currentelection != null)
            {
                currentelection.Pollnumber = election.Pollnumber;
                currentelection.Description = election.Description;
                currentelection.Position = election.Position;


                DbContext.Update(currentelection);
                DbContext.SaveChanges();
            }
            return election;
        }
        public List<Election> GetElections()
        {
            return DbContext.Elections.Include(d => d.Candidates).Where(d => d.DeletedDate == null).ToList();
        }
        public Election FindElectionById(int id)
        {
            return DbContext.Elections.Include(d => d.Candidates).FirstOrDefault(d => d.Pollnumber == id);
        }
        public List<ElectionResults> GetResults(int id)
        {
            List<ElectionResults> results = new List<ElectionResults>();

            var group = DbContext.Votes.Include(d => d.Candidate).Where(d => d.Election.Pollnumber== id).ToList().GroupBy(d => d.Candidate.Id);
            foreach(var g in group)
            {
                ElectionResults r = new ElectionResults();
                r.CandidateName = DbContext.Candidates.FirstOrDefault(d => d.Id == g.Key).FirstName;
                r.ElectionId = id;
                r.TotalVotes = g.Count();

                results.Add(r);
            }

            return results;
        }
    }
}
