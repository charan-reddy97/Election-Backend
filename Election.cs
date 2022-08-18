using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace VotingLibrary.Entities
{
    public class Election
    {
        [Key]
        public int Pollnumber { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public List<Candidate> Candidates { get => candidates; set => candidates = value; }

        List<Candidate> candidates = new List<Candidate>();
    }
}
