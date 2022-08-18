using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingLibrary.Entities;

namespace VotingLibrary.Repository
{
    public interface IELectionRepository
    {
        Election AddElection(Election election);
        void DeleteElection(int Id);
        Election FindElectionByName(string name);
        Election UpdateElection(Election election);
        List<Election> GetElections();
        Election FindElectionById(int Id);
        List<ElectionResults> GetResults(int Id);
    }
}
