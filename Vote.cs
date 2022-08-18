using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace VotingLibrary.Entities
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }
        public Election Election { get; set; }

        public Candidate Candidate { get; set; }
        public User Voter { get; set; }


    }
}
