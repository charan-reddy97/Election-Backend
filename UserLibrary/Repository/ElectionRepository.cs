using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp;
using VotingLibrary.Entities;

namespace UserLibrary.Repository
{
    public class ElectionRepository
    {
        VotingDbContext DbContext;
        public ElectionRepository(VotingDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        
        
        public Election FindElectionByName(string name)
        {
            return DbContext.Elections.FirstOrDefault(d => d.Position == name);
        }
        public List<Election> GetElections()
        {
            return DbContext.Elections.Include(d => d.Candidates).Where(d => d.DeletedDate == null).ToList();
        }
        public Election FindElectionById(int id)
        {
            return DbContext.Elections.Include(d => d.Candidates).FirstOrDefault(d => d.Pollnumber == id);
        }
    }
}
