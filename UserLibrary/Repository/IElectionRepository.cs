using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingLibrary.Entities;

namespace UserLibrary.Repository
{
    public class IElectionRepository
    {
        public interface IELectionRepository
        {
           
            Election FindElectionByName(string name);
            
            List<Election> GetElections();
            Election FindElectionById(int Id);
        }
    }
}
