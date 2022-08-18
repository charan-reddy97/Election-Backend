
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingLibrary.Entities
{
    public class ElectionResults
    {
        public int ElectionId { get; set; }
        public string CandidateName { get; set; }
        public int TotalVotes { get; set; }
    }
}
